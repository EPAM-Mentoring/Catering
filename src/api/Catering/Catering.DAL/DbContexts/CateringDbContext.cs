using Catering.DAL.Entities.Auth;
using Catering.DAL.Entities.Bookings;
using Catering.DAL.Entities.Buildings;
using Catering.DAL.Entities.FoodShops;
using Catering.DAL.Entities.Order;
using Catering.DAL.Entities.Restaurnt;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.DbContexts 
{
    public class CateringDbContext : IdentityDbContext<User, Role, int>
    {
        public CateringDbContext(DbContextOptions<CateringDbContext> options) : base(options)
        {

        }

        public DbSet<FoodShop> FoodShops { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Building> Buildings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
