using System;
using System.Collections.Generic;
using static Gof4Demo.SimpeChainOfResponsibility.ChainOfResponsibilityExample;

namespace Gof4Demo.SimpeChainOfResponsibility
{
    public class FilterString
    {
        StringFilterBuilder _stringFilterBuilder;

        public FilterString()
        {
            _stringFilterBuilder = new StringFilterBuilder();

            _stringFilterBuilder.Add(new NameFilter());
            _stringFilterBuilder.Add(new PlaceFilter());

        }

        public void Filter()
        {
            var str = "小明今天在广州分享设计模式";
            var filterStr = _stringFilterBuilder.DoFilter(str);
            Console.WriteLine(filterStr);
        }
    }

    public class ChainOfResponsibilityExample
    {
        /// <summary>
        /// 处理数据上下文
        /// </summary>
        public class StringContext
        {
            public string Content { get; set; }
            public bool IsFinish { get; set; }
        }

        /// <summary>
        /// 处理的管道构建
        /// </summary>
        public class StringFilterBuilder
        {
            private List<IStringFilter> _filters = new List<IStringFilter>();

            public StringFilterBuilder Add(IStringFilter filter)
            {
                _filters.Add(filter);
                return this;
            }

            public string DoFilter(string str)
            {
                var context = new StringContext() { Content = str };

                foreach (var item in _filters)
                {
                    item.Invoke(context);
                    if (context.IsFinish)
                    {
                        return context.Content;
                    }
                }
                return context.Content;
            }
        }



        /// <summary>
        /// 定义处理的接口
        /// </summary>
        public interface IStringFilter
        {
            void Invoke(StringContext context);
        }

        /// <summary>
        /// 名字拦截实现
        /// </summary>
        public class NameFilter : IStringFilter
        {
            public void Invoke(StringContext context)
            {
                var nameList = new List<string> { "小明" };
                foreach (var item in nameList)
                {
                    context.Content = context.Content.Replace(item, "***");                    
                }
                context.IsFinish = true;
            }
        }

        /// <summary>
        /// 未知拦截实现
        /// </summary>
        public class PlaceFilter : IStringFilter
        {
            public void Invoke(StringContext context)
            {
                var placeList = new List<string> { "广州" };

                foreach (var item in placeList)
                {
                    context.Content = context.Content.Replace(item, "***");
                }
            }
        }



    }
}
