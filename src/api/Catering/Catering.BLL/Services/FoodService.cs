using Catering.BLL.Interfaces;
using Catering.DAL;
using Catering.DAL.DbContexts;
using Catering.DAL.Entities.FoodShops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Services
{
    public class FoodService : BaseService, IFoodService
    {
        private readonly IRepository<Food> _repository;

        public FoodService(IUnitOfWork unitOfWork, 
            IRepository<Food> repository) : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task AddFood(int shopId, Food food)
        {
            food.FoodShopId = shopId;

            _repository.Add(food);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task DeleteFood(Food food)
        {
            _repository.Delete(food);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task<Food> GetFood(int foodId)
        {
            return await _repository.GetAsync(foodId);
        }

        public async Task UpdateFood(Food food)
        {
            _repository.Update(food);

            await UnitOfWork.SaveChangeAsync();
        }

        public async Task<IEnumerable<Food>> GetFoods()
        {
            return await _repository.GetListAsync();
        }
    }
}
