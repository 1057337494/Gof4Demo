using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gof23Job.SingleCode
{
    /// <summary>
    /// 实现方式  通过CLR机制保证  
    /// 由于CLR保证静态方法构造函数 只会在调用的时候执行一次
    /// 所以使用内部静态类保证了线程安全和延迟加载
    /// </summary>
    public class StaticLazySingleByInnerObject
    {
        public string Name { get; set; }

        public string Description { get; set; }


        private StaticLazySingleByInnerObject(string name, string description)
        {
            Name = name;
            Description = description;
        }


        private static class InnerClass
        {
            public static StaticLazySingleByInnerObject InnerInstance = new StaticLazySingleByInnerObject("单例测试", "测试说明");
        }

        public static StaticLazySingleByInnerObject Instance => InnerClass.InnerInstance;


    }
}
