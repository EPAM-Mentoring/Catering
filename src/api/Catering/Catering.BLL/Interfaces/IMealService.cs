using Catering.DAL.Entities.Restaurnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Interfaces
{
    public interface IMealService
    {
        public Task<IEnumerable<Meal>> GetMeals();

        public Task<Meal> GetMeal(int mealId);

        public Task AddMeal(int restaurantId, Meal meal);

        public Task UpdateMeal(Meal meal);

        public Task DeleteMeal(Meal meal);
    }
}
