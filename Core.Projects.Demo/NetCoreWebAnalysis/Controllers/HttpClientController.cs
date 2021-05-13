using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis.Controllers
{
    /// <summary>
    /// 针对HttpClient使用的说明
    /// </summary>
    [Route("httpclient")]
    public class HttpClientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly BaiduHttpClient _baiduHttpClient;

        public HttpClientController(IHttpClientFactory httpClientFactory, BaiduHttpClient baiduHttpClient)
        {
            _httpClientFactory = httpClientFactory;
            _baiduHttpClient = baiduHttpClient;
        }

        /// <summary>
        /// 普通方式访问
        /// </summary>
        /// <returns></returns>
        [HttpGet("getbaidu")]
        public async Task<ActionResult> GetBaidu()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://www.baidu.com");
            string result = await client.GetStringAsync("/");
            return Ok(result);
        }

        /// <summary>
        /// 命名化方式
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBaiduClient")]
        public async Task<ActionResult> GetBaiduClient()
        {
            var client = _httpClientFactory.CreateClient("baidu");
            string result = await client.GetStringAsync("/");
            return Ok(result);
        }

        /// <summary>
        /// 类型化使用方式
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBaiduClient2")]
        public async Task<ActionResult> GetBaiduClient2()
        {
            string result = await _baiduHttpClient.GetBaidu();
            return Ok(result);
        }
    }
}
