using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis
{
    /// <summary>
    /// 创建IJob的实现类，并实现Excute方法
    /// </summary>
    public class TestJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("output testjob log");
            });
        }
    }
}
