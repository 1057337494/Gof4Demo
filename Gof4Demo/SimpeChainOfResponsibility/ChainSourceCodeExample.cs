using Castle.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimpeChainOfResponsibility
{
    public class ChainSourceCodeExample
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowCors");
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseApiCheck();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public static class MiddleWareExtensions
    {
        public static IApplicationBuilder UseApiCheck(this IApplicationBuilder app)
        {
           return app.UseMiddleware<ApiAuthCheckMiddleware>();            
        }
    }

    public class ApiAuthCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public ApiAuthCheckMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
          
            var token = context.Request.Headers["Authorization"].ToString();
            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            if (endpoint == null)
            {
                await _next(context);
                return;
            }
        }
    }


}
