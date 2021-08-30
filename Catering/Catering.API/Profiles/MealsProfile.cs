using AutoMapper;
using Catering.API.Dtos;
using Catering.DAL.Entities.Restaurnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Profiles
{
    public class MealsProfile : Profile
    {
        public MealsProfile()
        {
            CreateMap<Meal, MealDto>();
            CreateMap<MealCreateDto, Meal>();
            CreateMap<MealUpdateDto, Meal>();
            CreateMap<Meal, MealUpdateDto>();
        }
    }
}
