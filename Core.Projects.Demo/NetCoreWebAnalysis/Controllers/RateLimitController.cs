using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis.Controllers
{
    /// <summary>
    /// 流量限制使用说明
    /// </summary>
    [Route("api/rateLimit")]
    [ApiController]
    public class RateLimitController: Controller
    {
        [HttpGet("GetDateTime")]
        public string GetDateTime()
        {
            return DateTime.Now.ToString("d");
        }
    }
}
