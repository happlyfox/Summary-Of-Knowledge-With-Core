using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis
{
    public static class RateLimitedConfigureService
    {
        public static void RateLimitedConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //Option模式配置
            services.AddOptions();
            //存储速率限制计算器和ip规则
            services.AddMemoryCache();
            //加载ip限制通用策略
            services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
            //加载ip限制定制策略，即针对某一个ip的特殊限制，可选择性注释
            //services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

            //注入计数器和规则存储
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            //httpContext使用需要注入的服务
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //配置（解析器、计数器密钥生成器）
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}
