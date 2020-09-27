using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Gof4Demo.SimplePolicy;
using Gof4Demo.SimpleProxy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Gof4Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
             .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             //.AddCustomAuth(o => { })
             .AddJwtBearer(options => {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidIssuer ="",
                     ValidAudience = "",
                      ClockSkew = TimeSpan.Zero
                 };
             });

            services.AddControllers();

           

            services.AddAuthorization(s => s.AddPolicy("policy1", s => s.Requirements.Add(new MinAgePolicy(18)))); 


        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<UserInterceptor>();//×¢²áÀ¹½ØÆ÷
            builder.RegisterType<User>().As<IUser>().InterceptedBy(typeof(UserInterceptor)).EnableInterfaceInterceptors();//×¢²áCat²¢ÎªÆäÌí¼ÓÀ¹½ØÆ÷
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
