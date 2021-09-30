using Catering.DAL.Entities.Buildings;
using Catering.DAL.Entities.Restaurnt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Configuration
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
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
                .Property(m => m.PictureUrl)
                .IsRequired();

            builder
                .Property(m => m.OpenTime)
                .IsRequired();

            builder
                .Property(m => m.ClosedTime)
                .IsRequired();

            builder
                .HasOne(a => a.Building)
                .WithOne(b => b.Restaurant)
                .HasForeignKey<Building>(b => b.RestaurantId);

            builder
                .ToTable("Restaurants");
        }
    }
}
