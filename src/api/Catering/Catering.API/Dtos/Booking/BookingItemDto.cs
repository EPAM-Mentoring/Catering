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

        public TimeSpan OpenTime { get; set; }

        public TimeSpan ClosedTime { get; set; }
    }
}
