using Microsoft.AspNetCore.Mvc;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis.Controllers
{
    [Route("quart")]
    [ApiController]
    public class QuartController : Controller
    {
        private readonly ISchedulerFactory _schedulerFactory;

        public QuartController(ISchedulerFactory schedulerFactory)
        {
            _schedulerFactory = schedulerFactory;
        }

        [HttpGet("CreateTask")]
        public async Task<IActionResult> CreateTask()
        {
            //通过调度工厂获得调度器
            var _scheduler = await _schedulerFactory.GetScheduler();
            //开启调度器
            await _scheduler.Start();
            //创建一个触发器
            var trigger = TriggerBuilder.Create()
                            .WithSimpleSchedule(x => x.WithIntervalInSeconds(2).RepeatForever())//每两秒执行一次
                            .Build();
            //创建任务
            var jobDetail = JobBuilder.Create<TestJob>()
                            .WithIdentity("job", "group")
                            .Build();

            //将触发器和任务器绑定到调度器中
            await _scheduler.ScheduleJob(jobDetail, trigger);

            return new JsonResult(new { success = true });
        }

    }
}
