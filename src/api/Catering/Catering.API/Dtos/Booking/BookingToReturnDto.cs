using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos.Booking
{
    public class BookingToReturnDto
    {
        public int Id { get; set; }

        public string CustomerEmail { get; set; }

        public DateTimeOffset BookingDate { get; set; }

        public ICollection<BookingItemDto> BookingItems { get; set; }

        public string Status { get; set; }
    }
}
