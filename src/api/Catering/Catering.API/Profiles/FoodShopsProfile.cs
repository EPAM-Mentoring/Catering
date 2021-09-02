using AutoMapper;
using Catering.API.Dtos;
using Catering.DAL.Entities.FoodShops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Profiles
{
    public class FoodShopsProfile : Profile
    {
        public FoodShopsProfile()
        {
            CreateMap<FoodShop, FoodShopDto>();
            CreateMap<FoodShopCreateDto, FoodShop>();
        }
    }
}
