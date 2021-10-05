using Catering.DAL.Configuration;
using Catering.DAL.Entities.Auth;
using Catering.DAL.Entities.Basket;
using Catering.DAL.Entities.Bookings;
using Catering.DAL.Entities.Buildings;
using Catering.DAL.Entities.FoodShops;
using Catering.DAL.Entities.Order;
using Catering.DAL.Entities.Restaurnt;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Catering.DAL.DbContexts 
{
    public class CateringDbContext : IdentityDbContext<User>
    {
        public CateringDbContext(DbContextOptions<CateringDbContext> options) : base(options)
        {

        }

        public DbSet<FoodShop> FoodShops { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<MealOrderItem> MealOrderItems { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingItem> BookingItems { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<CustomerBasket> CustomerBaskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<MealBasketItem> MealBasketItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RestaurantConfiguration());
            builder.ApplyConfiguration(new FoodShopConfiguration());
            builder.ApplyConfiguration(new MealConfiguration());
            builder.ApplyConfiguration(new FoodConfiguration());
            builder.ApplyConfiguration(new BuildingConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new MealOrderItemConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new BookingConfiguration());
            builder.ApplyConfiguration(new BookingItemConfiguration());
            builder.ApplyConfiguration(new DeliveryMethodConfiguration());
        }
    }
}
