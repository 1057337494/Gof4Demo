using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gof23Job.SingleCode
{
    /// <summary>
    /// 饱汉式
    /// 
    /// </summary>
    public class StaticSingleObject
    {
        public string Name { get; set; }

        public string Description { get; set; }


        private StaticSingleObject(string name, string description)
        {
            Name = name;
            Description = description;
        }


        public static StaticSingleObject Instance = new StaticSingleObject("单例测试", "测试说明");

    }
}
