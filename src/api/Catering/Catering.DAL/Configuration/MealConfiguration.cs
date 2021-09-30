using Catering.Common.Constants;
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
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.MealName)
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
                .HasOne(m => m.Restaurant)
                .WithMany(a => a.Meals)
                .HasForeignKey(m => m.RestaurantId);

            builder
                .ToTable("Meals");
        }
    }
}
