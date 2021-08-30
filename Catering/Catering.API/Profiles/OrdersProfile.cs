using AutoMapper;
using Catering.API.Dtos.Order;
using Catering.DAL.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<OrderDto, Order>();
        }
    }
}
