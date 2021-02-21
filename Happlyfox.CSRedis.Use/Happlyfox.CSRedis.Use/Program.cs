using CSRedis;
using System;
using System.Threading;

namespace Happlyfox.CSRedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //连接哨兵模式
            var csredis = new CSRedis.CSRedisClient("mymaster,password=123456,poolsize=50,connectTimeout=200,ssl=false", new[] {
                "192.168.26.11:26379",
                "192.168.26.12:26379",
                "192.168.26.13:26379"
            });

            //初始化 RedisHelper
            RedisHelper.Initialization(csredis);

            while (true)
            {
                try
                {
                    Test();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.ReadLine();
            }

            Console.ReadKey();
        }

        static void Test()
        {
            RedisHelper.Set("name", "祝雷");//设置值。默认永不过期
            Console.WriteLine(RedisHelper.Get<string>("name"));

            RedisHelper.Set("time", DateTime.Now, 1);
            Console.WriteLine(RedisHelper.Get<DateTime>("time"));
            Console.WriteLine(RedisHelper.Get<DateTime>("time"));

            // 列表
            RedisHelper.RPush("list", "第一个元素");
            RedisHelper.RPush("list", "第二个元素");
            RedisHelper.LInsertBefore("list", "第二个元素", "我是新插入的第二个元素！");
            Console.WriteLine($"list的长度为{RedisHelper.LLen("list")}");
            Console.WriteLine($"list的第二个元素为{RedisHelper.LIndex("list", 1)}");
        }
    }
}