using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis.Models
{
    public class OrderOutPut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string CreateYear { get; set; }
        public string CreateMonth { get; set; }
        public string CreateDay { get; set; }
    }
}
