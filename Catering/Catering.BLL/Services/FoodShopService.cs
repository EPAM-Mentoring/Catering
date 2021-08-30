using Catering.BLL.Interfaces;
using Catering.DAL;
using Catering.DAL.DbContexts;
using Catering.DAL.Entities.FoodShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Services
{
    public class FoodShopService : BaseService, IFoodShopService
    {
        private readonly IRepository<FoodShop> _repository;

        public FoodShopService(IUnitOfWork unitOfWork, IRepository<FoodShop> repository) 
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task AddFoodShop(FoodShop foodShop)
        {
            _repository.Add(foodShop);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task DeleteFoodShop(FoodShop foodShop)
        {
            _repository.Delete(foodShop);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task<FoodShop> GetFoodShop(int shopId)
        {
            return await _repository.GetAsync(shopId);
        }

        public async Task<IEnumerable<FoodShop>> GetFoodShops()
        {
            return await _repository.GetListAsync();
        }

        public async Task UpdateFoodShop(FoodShop foodShop)
        {
             _repository.Update(foodShop);
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
