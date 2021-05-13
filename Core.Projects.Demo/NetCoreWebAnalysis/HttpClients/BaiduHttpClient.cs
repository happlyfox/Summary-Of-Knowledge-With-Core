using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis
{
    public class BaiduHttpClient
    {
        public HttpClient _client { get; private set; }

        public BaiduHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://www.baidu.com");
            _client = httpClient;
        }

        public async Task<string> GetBaidu()
        {
            return await _client.GetStringAsync("/");
        }
    }
}
