using Catering.API.Integrations;
using Catering.BLL.Interfaces;
using Catering.BLL.Services;
using Catering.DAL;
using Catering.DAL.DbContexts;
using Catering.DAL.Entities.Bookings;
using Catering.DAL.Entities.Buildings;
using Catering.DAL.Entities.FoodShops;
using Catering.DAL.Entities.Order;
using Catering.DAL.Entities.Restaurnt;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Configuration
{
    public static class DIConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CateringDbContext>();

            services.AddScoped<IRepository<Building>, Repository<Building>>();
            services.AddScoped<IRepository<Booking>, Repository<Booking>>();
            services.AddScoped<IRepository<Food>, Repository<Food>>();
            services.AddScoped<IRepository<FoodShop>, Repository<FoodShop>>();
            services.AddScoped<IRepository<Meal>, Repository<Meal>>();
            services.AddScoped<IRepository<Restaurant>, Repository<Restaurant>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IFoodService, FoodService>();

            services.AddScoped<IMealService, MealService>();

            services.AddScoped<IRestaurantService, RestaurantService>();

            services.AddScoped<IFoodShopService, FoodShopService>();

            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IBookingService, BookingService>();

            services.AddScoped<IBuildingService, BuildingService>();

            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
