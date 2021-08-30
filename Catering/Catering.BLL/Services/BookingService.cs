using Catering.BLL.Interfaces;
using Catering.DAL;
using Catering.DAL.Entities.Bookings;
using Catering.DAL.Entities.Restaurnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Services
{
    public class BookingService : BaseService, IBookingService
    {
        private readonly IRepository<Booking> _repository;

        public BookingService(IRepository<Booking> repository, 
              IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task CreateBooking(Booking booking)
        {
            _repository.Add(booking);
            await UnitOfWork.SaveChangeAsync();
        }

        public async  Task<Booking> GetAsync(int bookingId)
        {
            return await _repository.GetAsync(bookingId);
        }

        public async Task IsAvaliable(int bookingId, bool isAvaliable)
        {
            var booking = await _repository.GetAsync(bookingId);
            booking.IsAviable = isAvaliable;

            _repository.Update(booking);
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
