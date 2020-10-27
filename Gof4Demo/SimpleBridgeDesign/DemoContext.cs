using DotNetCore.CAP;
using EfDemo.Infrastructure.EfModelCreatingExtensions;
using Microsoft.EntityFrameworkCore;
using TY.Microservice.Common.Core;

namespace EfDemo.Infrastructure.EfContext
{


    public partial class DemoContext : EFContext
    {
        public DemoContext(DbContextOptions options, ICapPublisher capBus) : base(options, capBus)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region 注册领域模型与数据库的映射关系


            modelBuilder.ConfigureDemo();


            #endregion

        }


    }
}
