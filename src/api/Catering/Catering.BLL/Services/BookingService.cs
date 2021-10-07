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
        private readonly IRepository<Restaurant> _restaurantRepo;

        public BookingService(IRepository<Booking> repository, IRepository<Restaurant> restaurantRepo,
              IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task<Booking> CreateBooking(string customerEmail, int restaurantId)
        {
            var res = await UnitOfWork.Repository<Restaurant>().GetAsync(restaurantId);

            var items = new List<BookingItem>();
            items.Add(new BookingItem(new RestaurantBooked(res.Id, res.Name, res.PictureUrl), res.OpenTime, res.CloseTime));

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
