using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace NetCoreWebAnalysis.Controllers
{
    /// <summary>
    /// 配置文件访问、使用说明
    /// </summary>
    [Route("config")]
    public class ConfigController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IOptions<PersonOption> _personOption;

        public ConfigController(IConfiguration configuration, IOptions<PersonOption> personOption)
        {
            _configuration = configuration;
            _personOption = personOption;
        }

        /// <summary>
        /// 普通方式访问配置文件
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetConfig")]
        public IActionResult GetConfig()
        {
            string DefaultLevel = _configuration.GetSection("Logging").GetSection("LogLevel").GetSection("Default").Value;
            //使用key读取
            string LifetimeLevel = _configuration["Logging:LogLevel:Microsoft"];
            //使用GetValue<T>
            string MicrosoftLevel = _configuration.GetValue<string>("Logging:LogLevel:Microsoft");
            string TestLevel = _configuration.GetValue<string>("Logging:LogLevel:Test", "Debug");

            return new JsonResult(new
            {
                DefaultLevel,
                LifetimeLevel,
                MicrosoftLevel,
                TestLevel
            });
        }

        /// <summary>
        /// option模式访问配置文件
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOptionConfig")]
        public IActionResult GetOptionConfig()
        {
            var json = _personOption.Value;
            return new JsonResult(json);
        }
    }
}
