using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis.Models
{
    /// <summary>
    /// 工单
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
