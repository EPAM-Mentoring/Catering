using Catering.API.Integrations;
using Catering.BLL.Interfaces;
using Catering.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IFoodShopService, FoodShopService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }

    }
}
