using AutoMapper;
using Catering.API.Dtos;
using Catering.DAL.Entities.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Profiles
{
    public class RestaurantsProfile : Profile
    {
        public RestaurantsProfile()
        {
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantCreateDto, Restaurant>();
        }
    }
}
