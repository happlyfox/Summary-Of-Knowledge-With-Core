using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace SocketConsole
{
    class Program
    {
        //将一个数组按固定大小拆分为数组
        public static List<byte[]> splitAry(byte[] ary, int subSize)
        {
            int count = ary.Length % subSize == 0 ? ary.Length / subSize : ary.Length / subSize + 1;
            List<byte[]> subAryList = new List<byte[]>();
            for (int i = 0; i < count; i++)
            {
                int index = i * subSize;
                byte[] subary = ary.Skip(index).Take(subSize).ToArray();
                subAryList.Add(subary);
            }
            return subAryList;
        }

        static void Main(string[] args)
        {

            Dictionary<string, string> dics = new Dictionary<string, string>();
            dics.Add("1", "2");

            Console.WriteLine(dics["1"]);
            Console.WriteLine(dics.TryGetValue("2",out string box));
            Console.WriteLine(box);
            return;


            byte[] myByteArray = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52 }; //共18个数
            int subSize = 5;
            List<byte[]> subArrayList = splitAry(myByteArray, subSize);
            foreach (byte[] subary in subArrayList)
            {
                string str = Encoding.Default.GetString(subary);
                Console.WriteLine(str);
            }

            return;
            int recv;
            byte[] data = new byte[1024];
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 8002);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipEnd);
            socket.Listen(10);
            Console.WriteLine("Waiting for a client");
            Socket client = socket.Accept();
            IPEndPoint ipEndClient = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("Connect with {0} at port {1}", ipEndClient.Address, ipEndClient.Port);
            string welcome = "Welcome to my server";
            data = Encoding.ASCII.GetBytes(welcome);
            client.Send(data, data.Length, SocketFlags.None);
            while (true)
            {
                data = new byte[1024];
                recv = client.Receive(data);
                if (recv == 0)
                    break;
                Console.Write(Encoding.ASCII.GetString(data, 0, recv) + "\r\n");
                client.Send(data, recv, SocketFlags.None);
            }
            Console.WriteLine("Disconnect form{0}", ipEndClient.Address);
            client.Close();
            socket.Close();
        }
    }
}