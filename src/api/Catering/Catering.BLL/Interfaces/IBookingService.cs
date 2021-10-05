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
        public Task<Booking> CreateBooking(string customerEmail, int restaurantId);

        public Task<IReadOnlyList<Booking>> GetBookingsForUserAsync(string customerEmail);

        public Task<Booking> GetBookingByIdAsync(int id, string customerEmail);
    }
}
