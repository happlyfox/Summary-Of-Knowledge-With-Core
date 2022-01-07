using CodeFirstDemo.Services;
using Furion;
using Furion.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CodeFirstDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .Inject()
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                // 配置数据库上下文，支持N个数据库
                services.AddDatabaseAccessor(options =>
                {
                    // 配置默认数据库
                    options.AddDbPool<DefaultDbContext>();
                    options.AddDbPool<Test2DbContext, Test2DbLocator>();

                    // 配置多个数据库，多个数据库必须指定数据库上下文定位器
                    //  options.AddDbPool<SqliteDbContext, SqliteDbContextLocaotr>();
                }, "CodeFirstDemo");

                //var service = App.GetService<IHelloService>();
                //service.SayHello();

                var service = App.GetService<LocatorTestService>();
                service.GetDb1Person();
                service.GetDb2Person();
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {

            }
        }
    }
}
