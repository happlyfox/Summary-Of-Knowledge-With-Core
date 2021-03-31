using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Cache.Demo
{
    public class BackgroundJob : IHostedService
    {
        private readonly CacheService _cacheService;

        public BackgroundJob(CacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cacheService.ExpiredCache();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
