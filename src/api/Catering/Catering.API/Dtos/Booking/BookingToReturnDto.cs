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

        public DateTime BookingDate { get; set; }

        public ICollection<BookingItemDto> BookingItems { get; set; }
    }
}
