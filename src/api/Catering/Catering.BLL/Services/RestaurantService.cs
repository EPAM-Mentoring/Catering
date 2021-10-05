using Catering.BLL.Interfaces;
using Catering.DAL;
using Catering.DAL.DbContexts;
using Catering.DAL.Entities.Restaurnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Services
{
    public class RestaurantService : BaseService, IRestaurantService
    {
        private readonly IRepository<Restaurant> _repository;

        public RestaurantService(IUnitOfWork unitOfWork, IRepository<Restaurant> repository) 
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task AddRestaurant(Restaurant restaurant)
        {
            _repository.Add(restaurant);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task DeleteRestaurant(Restaurant restaurant)
        {
            _repository.Delete(restaurant);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task<Restaurant> GetRestaurant(int restaurantId)
        {
            return await _repository.GetAsync(restaurantId);
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            return await _repository.GetListAsync();
        }

        public async Task UpdateRestaurant(Restaurant restaurant)
        {
            _repository.Update(restaurant);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task UpdateRestaurantStatus(Restaurant restaurant)
        {
            restaurant.IsAvailableForBooking = false;
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
