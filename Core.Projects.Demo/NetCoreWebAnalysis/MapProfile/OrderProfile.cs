using AutoMapper;
using NetCoreWebAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis.MapProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderOutPut>()
                   .ForMember(des => des.CreateYear, source => source.MapFrom(i => i.CreateTime.Year))
                   .ForMember(des => des.CreateMonth, source => source.MapFrom(i => i.CreateTime.Month))
                   .ForMember(des => des.CreateDay, source => source.MapFrom(i => i.CreateTime.Day));
        }
    }
}
