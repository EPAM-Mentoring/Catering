using Catering.DAL.Entities.Restaurnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Interfaces
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<Restaurant>> GetRestaurants();

        public Task<Restaurant> GetRestaurant(int restaurantId);

        public Task AddRestaurant(Restaurant restaurant);

        public Task DeleteRestaurant(Restaurant restaurant);

        public Task UpdateRestaurant(Restaurant restaurant);

        public Task UpdateRestaurantStatus(Restaurant restaurant);
    }
}
