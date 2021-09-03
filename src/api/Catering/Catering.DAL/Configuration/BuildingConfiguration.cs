using Catering.DAL.Entities.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Configuration
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(m => m.Restaurant)
                .WithMany(a => a.Buildings)
                .HasForeignKey(m => m.RestaurantId);

            builder
                .HasOne(m => m.FoodShop)
                .WithMany(a => a.Buildings)
                .HasForeignKey(m => m.FoodShopId);

            builder
                .ToTable("Buildings");
        }
    }
}
