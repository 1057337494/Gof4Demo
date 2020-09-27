using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gof4Demo.SimpleTemplete
{
    public abstract class CacheTemplete<T>
    {
        private static IEnumerable<T> _cacheList;

        private DateTime _lastUpdateTime = DateTime.Now;

        private long _autoReloadSecond = 30;

        public IEnumerable<T> GetCache()
        {
            if (IsExpire())
            {
                lock (this)
                {
                    if (IsExpire())
                    {
                        ReloadCache();
                    }
                }
            }
            return _cacheList;
        }

        public void SetAutoReloadSecond(int second)
        {
            if (second <= 5)
            {
                throw new ArgumentException("最小刷新时间为5s");
            }
            _autoReloadSecond = second;
        }

        private bool IsExpire()
        {
            if (_lastUpdateTime.AddSeconds(_autoReloadSecond) < DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public void ClearCache()
        {
            _cacheList = new List<T>();
        }

        public void SetCache(IEnumerable<T> cacheData)
        {
            _cacheList = cacheData;
        }

        public IEnumerable<T> GetCache(Func<T,bool> exp)
        {
            return _cacheList.Where(exp);
        }

        public virtual void ReloadCache()
        {
            throw new Exception("未配置刷新缓存方法");
        }


    }
}
