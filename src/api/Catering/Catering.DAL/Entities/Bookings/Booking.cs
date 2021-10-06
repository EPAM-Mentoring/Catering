using Catering.DAL.Entities.Restaurnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Entities.Bookings
{
    public class Booking : BaseEntity
    {
        public Booking()
        {

        }

        public Booking(IReadOnlyList<BookingItem> bookingItems, string customerEmail)
        {
            CustomerEmail = customerEmail;
            BookingItems = bookingItems;
        }

        public IReadOnlyList<BookingItem> BookingItems { get; set; }
       
        public string CustomerEmail { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}
