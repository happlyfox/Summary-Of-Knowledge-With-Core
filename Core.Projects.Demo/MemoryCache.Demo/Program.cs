using Core.Cache.Demo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder().ConfigureServices((context, service) =>
            {
                service.AddScoped<CacheService>();

                service.AddHostedService<BackgroundJob>();

                service.AddMemoryCache();
            });

            await builder.RunConsoleAsync();
        }
    }
}
