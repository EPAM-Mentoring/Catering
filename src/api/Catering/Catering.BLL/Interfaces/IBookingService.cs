using Catering.DAL.Entities.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Interfaces
{
    public interface IBookingService 
    {
        public Task CreateBooking(Booking booking);

        public Task IsAvaliable(int bookingId, bool isAvaliable);

        public Task<Booking> GetAsync(int bookingId);
    }
}
