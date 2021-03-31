using CSRedis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace CSRedisCoreConsole
{

    public class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder().ConfigureServices((context, service) =>
            {

            });

            await builder.RunConsoleAsync();
        }


        public void OnlyDbInit()
        {
            var rds = new CSRedis.CSRedisClient("127.0.0.1:6379,password=123,defaultDatabase=0,poolsize=50,ssl=false,writeBuffer=10240");
            RedisHelper.Initialization(rds);

            RedisHelper.Set("test", DateTime.Now.ToString());
            RedisHelper.Get("test");
        }

        public void MultiDbInit()
        {
            var connectionString = "127.0.0.1:6379,password=123,poolsize=10";
            var redis = new CSRedisClient[14];
            for (var a = 0; a < redis.Length; a++)
                redis[a] = new CSRedisClient(connectionString + ",defaultDatabase=" + a);

            redis[0].Set("test", DateTime.Now.ToString());
            redis[0].Get("test");
        }

        public void SentinelInit()
        {
            var csredis = new CSRedis.CSRedisClient("mymaster,password=123",
   new[] { "192.169.1.10:26379", "192.169.1.11:26379", "192.169.1.12:26379" });

            csredis.Set("test", DateTime.Now.ToString());
            csredis.Get("test");
        }

        public void ClusterDbInit()
        {
            var csredis = new CSRedis.CSRedisClient(null,
  "127.0.0.1:6371,password=123,defaultDatabase=11,poolsize=10,ssl=false,writeBuffer=10240",
  "127.0.0.1:6372,password=123,defaultDatabase=12,poolsize=11,ssl=false,writeBuffer=10240",
  "127.0.0.1:6373,password=123,defaultDatabase=13,poolsize=12,ssl=false,writeBuffer=10240",
  "127.0.0.1:6374,password=123,defaultDatabase=14,poolsize=13,ssl=false,writeBuffer=10240");

            csredis.Set("test", DateTime.Now.ToString());
            csredis.Get("test");
        }
    }
}
