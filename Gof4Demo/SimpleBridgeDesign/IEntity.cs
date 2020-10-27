using System;
using System.Collections.Generic;
using System.Text;

namespace TY.Microservice.Common.Abstractions
{
    public interface IEntity
    {
    }

    public interface IEntity<Tkey>
    {
        /// <summary>
        /// 表ID
        /// </summary>
        Tkey Id { get; }
    }
}
