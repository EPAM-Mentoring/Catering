using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos
{
    public class BookingRequestDto
    {
        public int BookingId { get; set; }

        public int RestaurantId { get; set; }

        public string PersonId { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }
    }
}
