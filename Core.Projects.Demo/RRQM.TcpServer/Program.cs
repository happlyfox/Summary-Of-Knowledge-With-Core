using RRQMSocket;
using System;

namespace RRQM.TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpService<MyTcpSocketClient> service = new TcpService<MyTcpSocketClient>();
            service.ClientConnected += Service_ClientConnected;//订阅连接事件
            service.IsCheckClientAlive = false;
            service.MaxCount = 1000;
            service.Bind(8002, 10);

            Console.Read();
        }

        private static void Service_ClientConnected(object sender, MesEventArgs e)
        {
            MyTcpSocketClient tcpSocketClient = (MyTcpSocketClient)sender;

            Console.WriteLine($"客户端连接,Name={tcpSocketClient.Name},ID={tcpSocketClient.ID},Ip={tcpSocketClient.IP}");
        }
    }
}
