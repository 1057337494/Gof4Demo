using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TY.Microservice.Common.Abstractions;

namespace EfDemo.Infrastructure.EfEntities
{
    /// <summary>
    /// 部门表
    /// </summary>
    [Table("sys_dept")]
    public class SysDept : Entity<Guid>
    {
        /// <summary>
        /// 部门名
        /// </summary>
        [Description("部门名")]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 父级部门ID
        /// </summary>
        [Description("父级部门ID")]
        public Guid Parentid { get; set; }

        /// <summary>
        /// 节点
        /// </summary>
        [Description("节点")]
        [MaxLength(50)]
        public string Root { get; set; }

        public class EntityTypeConfiguration : IEntityTypeConfiguration<SysDept>
        {
            public void Configure(EntityTypeBuilder<SysDept> builder)
            {
                builder.HasKey(p => p.Id);
                builder.ToTable("sys_dept");
                //builder.Property(p => p.Name).HasMaxLength(20);
                builder.Property(p => p.Id).HasColumnType("char(36)");
                builder.Property(p => p.Parentid).HasColumnType("char(36)");
                //builder.Property(p => p.Root).HasMaxLength(20);

            }
        }
    }
}
