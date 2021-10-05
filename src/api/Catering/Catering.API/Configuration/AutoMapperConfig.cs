using AutoMapper;
using Catering.API.Dtos;
using Catering.API.Dtos.Auth;
using Catering.API.Dtos.Booking;
using Catering.API.Dtos.Order;
using Catering.DAL.Entities.Auth;
using Catering.DAL.Entities.Basket;
using Catering.DAL.Entities.Bookings;
using Catering.DAL.Entities.FoodShops;
using Catering.DAL.Entities.Order;
using Catering.DAL.Entities.Restaurnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Configuration
{
    public class AutoMapperConfig :Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddressDto, DAL.Entities.Order.Address>();
            CreateMap<DAL.Entities.Auth.Address, AddressDto>().ReverseMap();
            CreateMap<FoodShop, FoodShopDto>().ReverseMap();
            CreateMap<FoodShopCreateDto, FoodShop>().ReverseMap();
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<FoodCreateDto, Food>().ReverseMap() ;
            CreateMap<FoodUpdateDto, Food>().ReverseMap();
            CreateMap<Meal, MealDto>().ReverseMap();
            CreateMap<MealCreateDto, Meal>().ReverseMap();
            CreateMap<MealUpdateDto, Meal>().ReverseMap();
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
            CreateMap<RestaurantCreateDto, Restaurant>().ReverseMap();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<Order, OrderToReturnDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<Booking, BookingToReturnDto>();
            CreateMap<BookingItem, BookingItemDto>();
            CreateMap<UserDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}
