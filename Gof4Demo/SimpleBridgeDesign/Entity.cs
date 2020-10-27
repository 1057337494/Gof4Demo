using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TY.Microservice.Common.Abstractions
{
    public abstract class Entity : IEntity
    {
    }


    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }


    }
}
