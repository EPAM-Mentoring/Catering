using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos.Booking
{
    public class BookingItemDto
    {
        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        public string PictureUrl { get; set; }

        public DateTimeOffset OpenTime { get; set; }

        public DateTimeOffset ClosedTime { get; set; }
    }
}
