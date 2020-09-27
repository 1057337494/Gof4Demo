using System;
using System.Linq;
using static Gof4Demo.SimpleBuilder.SimpleBuildExample.Triangle;

namespace Gof4Demo.SimpleBuilder
{
    public class SimpleBuildExample
    {
        public void GetTriangle()
        {
           // var triangle = new TriangleBuilder().SetLineOne(3).SetLineTow(4).SetLineThree(5).Build();
            var triangle = new TriangleBuilder().SetLineOne(3).SetLineTow(4).SetLineThree(50).Build();
            Console.WriteLine($"角度A:{triangle.AngleA};角度B:{triangle.AngleB};角度C:{triangle.AngleC};");
        }




        public class Triangle
        {
            private Triangle(TriangleBuilder build)
            {
                LineOne = build.LineOne;
                LineTwo = build.LineTwo;
                LineThree = build.LineThree;
            }

            public decimal LineOne { get; }
            public decimal LineTwo { get; }
            public decimal LineThree { get; }
            public double AngleA => GetAngle(LineOne, LineTwo, LineThree);
            public double AngleB => GetAngle(LineOne, LineThree, LineTwo);
            public double AngleC => GetAngle(LineThree, LineTwo, LineOne);

            private double GetAngle(decimal one, decimal two, decimal three)
            {
                var cos = (Math.Pow((double)one, 2) + Math.Pow((double)two, 2) - Math.Pow((double)three, 2)) / (double)(2 * one * two);
                var acos = Math.Acos(cos);
                return 180 / Math.PI * acos;
            }

            public class TriangleBuilder
            {
                public decimal LineOne { get; private set; }
                public decimal LineTwo { get; private set; }
                public decimal LineThree { get; private set; }

                public TriangleBuilder SetLineOne(decimal lineLong)
                {
                    if (lineLong <= 0)
                    {
                        throw new ArgumentException("长度不可以小于等于0");
                    }
                    LineOne = lineLong;
                    return this;
                }

                public TriangleBuilder SetLineTow(decimal lineLong)
                {
                    if (lineLong <= 0)
                    {
                        throw new ArgumentException("长度不可以小于等于0");
                    }
                    LineTwo = lineLong;
                    return this;
                }

                public TriangleBuilder SetLineThree(decimal lineLong)
                {
                    if (lineLong <= 0)
                    {
                        throw new ArgumentException("长度不可以小于等于0");
                    }
                    LineThree = lineLong;
                    return this;
                }

                public Triangle Build()
                {
                    var lineList = new decimal[] { LineOne, LineThree, LineTwo };
                    var max = lineList.Max();
                    var min = lineList.Min();
                    if(lineList.Sum()-max<=max&& lineList.Sum() - min >= min)
                    {
                        throw new ArgumentException("三角形边关系不成立");
                    }

                    return new Triangle(this);
                }

            }

        }



    }
}
