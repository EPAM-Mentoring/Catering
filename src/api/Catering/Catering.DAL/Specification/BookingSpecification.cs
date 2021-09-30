using Catering.DAL.Entities.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Specification
{
    public class BookingSpecification : BaseSpecification<Booking>
    {
        public BookingSpecification(string email) : base(o => o.CustomerEmail == email)
        {
            AddOrderByDescending(o => o.BookingDate);
        }

        public BookingSpecification(int id, string email) : base(o => o.Id == id && o.CustomerEmail == email)
        {

        }
    }
}
