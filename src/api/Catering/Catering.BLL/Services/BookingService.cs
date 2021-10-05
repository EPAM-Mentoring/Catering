using Catering.BLL.Interfaces;
using Catering.DAL;
using Catering.DAL.Entities.Bookings;
using Catering.DAL.Entities.Restaurnt;
using Catering.DAL.Specification;
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

        public async Task<Booking> CreateBooking(string customerEmail, int restaurantId)
        {
            //var bookingOrder = await _bookingOrderRepository.GetAsync(bookingOrderId);
            var res = await UnitOfWork.Repository<Restaurant>().GetAsync(restaurantId);
            var items = new List<BookingItem>();
            
            /*foreach(var item in bookingOrder.Items)
            {
                var restaurantItem = await UnitOfWork.Repository<Restaurant>().GetAsync(item.Id);
                var itemBooked = new RestaurantBooked(restaurantItem.Id, restaurantItem.Name, restaurantItem.PictureUrl);
                var bookingItem = new BookingItem(itemBooked, restaurantItem.OpenTime, restaurantItem.CloseTime);
                items.Add(bookingItem);
            } */

            var booking = new Booking(items, customerEmail);
            _repository.Add(booking);

            await UnitOfWork.SaveChangeAsync();

            return booking;
        }

        public async Task<Booking> GetBookingByIdAsync(int id, string customerEmail)
        {
            var spec = new BookingSpecification(id, customerEmail);

            return await UnitOfWork.Repository<Booking>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Booking>> GetBookingsForUserAsync(string customerEmail)
        {
            var spec = new BookingSpecification(customerEmail);

            return await UnitOfWork.Repository<Booking>().ListAsync(spec);
        }
    }
}
