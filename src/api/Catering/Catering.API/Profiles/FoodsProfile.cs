using AutoMapper;
using Catering.API.Dtos;
using Catering.DAL.Entities.FoodShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Profiles
{
    public class FoodsProfile : Profile
    {
        public FoodsProfile()
        {
            CreateMap<Food, FoodDto>();
            CreateMap<FoodCreateDto, Food>();
            CreateMap<FoodUpdateDto, Food>();
            CreateMap<Food, FoodUpdateDto>();
        }
    }
}
