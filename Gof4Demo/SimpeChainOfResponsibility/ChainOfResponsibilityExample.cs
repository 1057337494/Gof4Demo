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
           // _stringFilterBuilder.Add(new PlaceFilter());

        }

        public void Filter()
        {
            var str = "刘广南今天在广州分享设计模式";
            var filterStr = _stringFilterBuilder.DoFilter(str);
            Console.WriteLine(filterStr);
        }
    }

    public class ChainOfResponsibilityExample
    {


        public class StringFilterBuilder
        {
            private List<IStringFilter> _filters = new List<IStringFilter>();

            public StringFilterBuilder Add(IStringFilter filter)
            {
                _filters.Add(filter);
                return this;
            }

            public string DoFilter(string val)
            {
                foreach (var item in _filters)
                {
                    val = item.Invoke(val);
                }
                return val;
            }
        }

       


        public interface IStringFilter
        {
            string Invoke(string val);
        }


        public class NameFilter : IStringFilter
        {
            public string Invoke(string val)
            {
                var nameList = new List<string> { "刘广南" };
                foreach (var item in nameList)
                {
                    val = val.Replace(item, "***");
                }
                return val;
            }
        }

        public class PlaceFilter : IStringFilter
        {
            public string Invoke(string val)
            {
                var placeList = new List<string> { "广州" };

                foreach (var item in placeList)
                {
                    val = val.Replace(item, "***");
                }
                return val;
            }
        }



    }
}
