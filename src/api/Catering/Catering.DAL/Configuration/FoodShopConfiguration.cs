using Catering.DAL.Entities.FoodShops;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Configuration
{
    public class FoodShopConfiguration : IEntityTypeConfiguration<FoodShop>
    {
        public void Configure(EntityTypeBuilder<FoodShop> builder)
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
                .ToTable("FoodShops");
        }
    }
}
