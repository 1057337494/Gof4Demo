using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimplePubSub
{
    public class SimpleEventBus
    {
        public const string LineA = "OrderNotify";
        public const string LineB = "AccountNotify";


        private Dictionary<string,List<Action<object>>> _register = new Dictionary<string, List<Action<object>>>();



        public void Publish(string name,object val)
        {
            if (_register.ContainsKey(name))
            {
                var actionList = _register[name];
                foreach (var item in actionList)
                {
                    item.Invoke(val);
                }
            }
        }

        public void Sub(string name,Action<object> action)
        {
            if(action==null)
            {
                throw new ArgumentException("不能注册空方法");
            }

            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("不能使用空名字注册");
            }

            if(_register.ContainsKey(name))
            {
                _register[name].Add(action);
            }
            else
            {
                _register.Add(name, new List<Action<object>> { action});
            }
        }


    }



    public class SimplePubSubExample
    {
        private SimpleEventBus _notifyLine;

        public SimplePubSubExample()
        {
            _notifyLine = new SimpleEventBus();

            _notifyLine.Sub(SimpleEventBus.LineA, NotifyOrderCreate);
            _notifyLine.Sub(SimpleEventBus.LineA, OrderSendEmail);
            _notifyLine.Sub(SimpleEventBus.LineA, Log);

            _notifyLine.Sub(SimpleEventBus.LineB, NotifyAccountCreate);
            _notifyLine.Sub(SimpleEventBus.LineB, Log);

        }


        public void CreateOrder()
        {
            var orderId = Guid.NewGuid();
            Console.WriteLine($"订单创建[{orderId}]");
            _notifyLine.Publish(SimpleEventBus.LineA, orderId);
        }

        private void NotifyOrderCreate(object id)
        {
            var orderId = (Guid)id;
            Console.WriteLine($"接收到订单创建[{orderId}]消息，发送通知");
        }

        private void OrderSendEmail(object id)
        {
            var orderId = (Guid)id;
            Console.WriteLine($"接收到订单创建[{orderId}]消息，发送邮件");
        }

        private void Log(object id)
        {
            var logInfoId = (Guid)id;
            Console.WriteLine($"记录日志[{logInfoId}]消息");
        }

        public void CreateAccount()
        {
            var accountId = Guid.NewGuid();
            Console.WriteLine($"用户创建[{accountId}]");
            _notifyLine.Publish(SimpleEventBus.LineB, accountId);
        }

        private void NotifyAccountCreate(object id)
        {
            var accountId = (Guid)id;
            Console.WriteLine($"接收到用户创建[{accountId}]消息，发送通知");
        }

       


    }
}
