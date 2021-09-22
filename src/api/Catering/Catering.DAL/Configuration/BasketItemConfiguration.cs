using Catering.Common.Constants;
using Catering.DAL.Entities.Basket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Configuration
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
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
                .Property(m => m.PictureUrl)
                .IsRequired();

            builder
                .Property(m => m.Price)
                .IsRequired()
                .HasColumnType(ConstantValues.PriceDecimalType);

            builder
                .Property(m => m.Quantity)
                .IsRequired();

            builder
                .ToTable("BasketItems");
        }
    }
}
