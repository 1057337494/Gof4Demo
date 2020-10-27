using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimpleBridgeDesign
{
    public class SimpleBridgeExample
    {
        public interface ISend
        {
            /// <summary>
            /// 发送方法
            /// </summary>
            void Send(string msg);
        }

        public class EmailSend : ISend
        {
            public void Send(string msg)
            {
                Console.WriteLine($"通过邮件发送消息:{msg}");
            }
        }

        public class PhoneSend : ISend
        {
            public void Send(string msg)
            {
                Console.WriteLine($"通过手机发送消息:{msg}");
            }
        }


        public abstract class Notification
        {
            protected ISend _send;

            public Notification(ISend send)
            {
                _send = send;
            }

            public abstract void Notify(string msg);
        }

        public class UserNotification : Notification
        {
            protected ISend _send;

            public UserNotification(ISend send) : base(send)
            {
            }

            public override void Notify(string msg)
            {
                _send.Send(msg);
            }
        }

        public void NofityBll()
        {
            var send = new EmailSend();
            var nofity = new UserNotification(send);
            nofity.Notify("注册了用户");
        }

    }

    public class SimpleBridgeExample2
    {
        public interface ITrousers
        {
            void DressTrousers();
        }

        public class YelloTrousers : ITrousers
        {
            public void DressTrousers()
            {
                Console.WriteLine("穿上黄色裤子");
            }
        }

        public class GreyTrousers : ITrousers
        {
            public void DressTrousers()
            {
                Console.WriteLine("穿上灰色裤子");
            }
        }


        public interface IClothes
        {
            void DressClothes();
        }

        public class GreyClothes : IClothes
        {
            public void DressClothes()
            {
                Console.WriteLine("穿上灰色衣服");
            }
        }

        public class BlueClothes : IClothes
        {
            public void DressClothes()
            {
                Console.WriteLine("穿上蓝色衣服");
            }
        }

        public interface IHat
        {
            void DressHat();
        }

        public class BlueHat : IHat
        {
            public void DressHat()
            {
                Console.WriteLine("穿上蓝色帽子");
            }
        }

        public class RedHat : IHat
        {
            public void DressHat()
            {
                Console.WriteLine("穿上红色帽子");
            }
        }


        public abstract class Person
        {
            private IClothes _clothes;

            private ITrousers _trousers;

            private IHat _hat;




            void Dress() { 
            
            
            }
        }




        public void NofityBll()
        {
           
        }

    }
}
