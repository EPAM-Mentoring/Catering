using Catering.Common.Constants;
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
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.FoodName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(m => m.PictureUrl)
                .IsRequired();

            builder
                .Property(m => m.Price)
                .IsRequired()
                .HasColumnType(ConstantValues.PriceDecimalType);

            builder
                .HasOne(m => m.FoodShop)
                .WithMany(a => a.Foods)
                .HasForeignKey(m => m.FoodShopId);

            builder
                .ToTable("Foods");
        }
    }
}
