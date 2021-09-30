using Catering.Common.Constants;
using Catering.DAL.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(i => i.ItemOrdered, io => { io.WithOwner(); });

            builder
                .Property(m => m.Price)
                .IsRequired()
                .HasColumnType(ConstantValues.PriceDecimalType);

            builder
                .ToTable("OrderItems");

        }
    }
}
