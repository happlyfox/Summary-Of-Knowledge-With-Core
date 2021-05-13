using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis
{
    public static class HttpClientConfigureService
    {
        public static void HttpClientUse(this IServiceCollection services)
        {
            //使用httpclient必要注入
            services.AddHttpClient();
            //命名方式注入
            services.AddHttpClient("baidu", c =>
            {
                c.BaseAddress = new Uri("http://www.baidu.com");
            });
            //类型化Client注入
            services.AddHttpClient<BaiduHttpClient>();
        }
    }
}
