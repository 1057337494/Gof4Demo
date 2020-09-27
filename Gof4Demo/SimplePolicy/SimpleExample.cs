using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimplePolicy
{
    public class SimpleExample
    {
        public class DemoBll
        {

            public DemoBll()
            {
                _policyTable = new Dictionary<string, CulMethod>
                {
                    ["+"] = Add,
                    ["-"] = Subtraction,
                    ["*"] = Multiplication,
                    ["/"] = Division,
                };
            }

            public int Cul(string culChar, int num1, int num2)
            {
                //if("+".Equals(culChar))
                //{
                //    return num1 + num2;
                //}
                //else if ("-".Equals(culChar))
                //{
                //    return num1 - num2;
                //}
                //else if ("*".Equals(culChar))
                //{
                //    return num1 * num2;
                //}
                //else if ("/".Equals(culChar))
                //{
                //    return num1 / num2;
                //}
                //else
                //{
                //    throw new ArgumentException("未定义的操作符");
                //}

                switch (culChar)
                {
                    case "+":
                        return num1 + num2;

                    case "-":
                        return num1 - num2;

                    case "*":
                        return num1 * num2;

                    case "/":
                        return num1 / num2;
                    default:
                        throw new ArgumentException("未定义的操作符");
                }
            }

            public int Cul2(string culChar, int num1, int num2)
            {
                var method = GetCulPolicy(culChar);
                return method.Invoke(num1, num2);
            }

            private CulMethod GetCulPolicy(string culChar)
            {
                if (!_policyTable.ContainsKey(culChar))
                {
                    throw new ArgumentException("未定义的操作符");
                }

                return _policyTable[culChar];
            }


            delegate int CulMethod(int num1, int num2);

            private Dictionary<string, CulMethod> _policyTable;

            private int Add(int num1, int num2)
            {
                return num1 + num2;
            }

            private int Division(int num1, int num2)
            {
                if (num2 == 0)
                {
                    throw new ArgumentException("除数不可以为0");
                }

                return num1 / num2;
            }

            private int Subtraction(int num1, int num2)
            {
                return num1 - num2;
            }

            private int Multiplication(int num1, int num2)
            {
                return num1 * num2;
            }

        }


        public interface ICulPolicy
        {
            public int Invoke(int num1, int num2);
        }

        public class AddPolicy : ICulPolicy
        {
            private ILogger _logger;

            public AddPolicy(ILogger logger)
            {
                _logger = logger;
            }

            public int Invoke(int num1, int num2)
            {
                return num1 + num2;
            }
        }

        public static class CulPolicyProvider
        {
            private static Dictionary<string, ICulPolicy> _culPolicyTable=new Dictionary<string, ICulPolicy>();


            public static void AddPolicy(string culChar, ICulPolicy culPolicy)
            {
                _culPolicyTable.Add(culChar, culPolicy);
            }


            //public static ICulPolicy GetPolicy(string culChar)
            //{
            //    var fac=

            //    _culPolicyTable.Add(culChar, culPolicy);
            //}
        }









    }
}
