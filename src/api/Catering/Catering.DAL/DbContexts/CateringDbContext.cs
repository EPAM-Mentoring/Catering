using Catering.DAL.Entities.Bookings;
using Catering.DAL.Entities.Buildings;
using Catering.DAL.Entities.FoodShops;
using Catering.DAL.Entities.Order;
using Catering.DAL.Entities.Restaurnt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.DbContexts 
{
    public class CateringDbContext : DbContext
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
    }
}
