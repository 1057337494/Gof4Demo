using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gof23Job.SingleCode
{
    /// <summary>
    /// 懒汉式
    /// 使用双重锁定保障线程安全
    /// </summary>
    public class StaticLazySingleObject
    {
        public string Name { get; set; }

        public string Description { get; set; }


        private StaticLazySingleObject(string name, string description)
        {
            Name = name;
            Description = description;
        }

        private static StaticLazySingleObject _innerInstance;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static StaticLazySingleObject GetInstance()
        {
            if (_innerInstance == null)
            {
                _innerInstance = new StaticLazySingleObject("单例测试", "测试说明");
            }

            return _innerInstance;
        }


    }
}
