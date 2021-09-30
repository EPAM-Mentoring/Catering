using Catering.DAL.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Configuration
{
    public class BookingItemConfiguration : IEntityTypeConfiguration<BookingItem>
    {
        public void Configure(EntityTypeBuilder<BookingItem> builder)
        {
            builder.OwnsOne(i => i.ResBooked, io => { io.WithOwner(); });

            builder
                .ToTable("BookingItems");
        }
    }
}
