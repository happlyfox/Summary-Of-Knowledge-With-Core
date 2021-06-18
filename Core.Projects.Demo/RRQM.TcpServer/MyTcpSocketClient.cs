using RRQMCore.ByteManager;
using RRQMSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace RRQM.TcpServer
{
    public class MyTcpSocketClient : TcpSocketClient
    {
        /// <summary>
        /// 初次创建对象，效应相当于构造函数，但是调用时机在构造函数之后，可覆盖父类方法
        /// </summary>
        public override void Create()
        {
            this.DataHandlingAdapter = new NormalDataHandlingAdapter();//普通TCP报文处理器
        }

        private int count;

        protected override void HandleReceivedData(ByteBlock byteBlock, object obj)
        {
            this.Recreate();

            count++;
            if (count % 1 == 0)
            {
                string mes = Encoding.UTF8.GetString(byteBlock.Buffer, 0, (int)byteBlock.Length);
                Console.WriteLine($"已接收到信息：{mes},第{count}条");
            }

            if (this.Online)
            {
                Console.WriteLine("online");

                var randown = new Random();
                string msg = $"dyMap_20210521101549_00009356_06420_0_603249|603249|u|06420016|{randown.Next(0,60)}|60|{randown.Next(1,10)}|1|0|32.1886356506298|118.722610532929|ha|193,dyMap_20210521101549_00009357_05020_0_608524|608524|u|05020030|{randown.Next(0, 60)}|48|{randown.Next(1, 10)}|1|0|32.2094028030425|118.728777518425|na|194,dyMap_20210521101549_00009358_06560_0_603351|603351|u|06560019|{randown.Next(0, 60)}|38|{randown.Next(1, 10)}|1|0|32.2216040567496|118.754050483805|na|242";
                this.Send(Encoding.UTF8.GetBytes(msg));

                //this.Send(byteBlock);//回传消息
            }
            else
            {
                Console.WriteLine("unonline");
            }
        }
    }
}
