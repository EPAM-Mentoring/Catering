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
    public class MealService : BaseService, IMealService
    {
        private readonly IRepository<Meal> _repository;

        public MealService(IUnitOfWork unitOfWork, IRepository<Meal> repository) 
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task AddMeal(int restaurantId, Meal meal)
        {
            meal.RestaurantId = restaurantId;
            _repository.Add(meal);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task DeleteMeal(Meal meal)
        {
            _repository.Delete(meal);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task<Meal> GetMeal(int mealId)
        {
            return await _repository.GetAsync(mealId);
        }

        public async Task<IEnumerable<Meal>> GetMeals()
        {
            return await _repository.GetListAsync();
        }

        public async Task UpdateMeal(Meal meal)
        {
            _repository.Update(meal);
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
