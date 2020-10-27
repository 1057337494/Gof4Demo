using EfDemo.Infrastructure.EfContext;
using EfDemo.Infrastructure.EfEntities;
using System;
using TY.Microservice.Common.Core;

namespace EfDemo.Infrastructure.EfRepositories
{
    public class DeptRepository : BaseRepository<SysDept, Guid, DemoContext>
    {
        public DeptRepository(DemoContext dbContext) : base(dbContext)
        {
        }

       

    }
}
