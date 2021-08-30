using Catering.DAL.Entities.FoodShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Interfaces
{
    public interface IFoodService
    {
        public Task<IEnumerable<Food>> GetFoods();

        public Task<Food> GetFood(int foodId);

        public Task AddFood(int shopId, Food food);

        public Task UpdateFood(Food food);

        public Task DeleteFood(Food food); 
    }
}
