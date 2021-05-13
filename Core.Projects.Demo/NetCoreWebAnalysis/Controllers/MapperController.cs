using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis.Controllers
{
    [Route("mapper")]
    [ApiController]
    public class MapperController : Controller
    {
        private readonly IMapper _mapper;

        public MapperController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("getmapper")]
        public OrderOutPut GetMapper()
        {
            var order = new Order()
            {
                Id = 1,
                Name = "工单1号",
                Desc = "工单描述内容",
                CreateTime = DateTime.Now
            };
            return _mapper.Map<OrderOutPut>(order);
        }
    }
}
