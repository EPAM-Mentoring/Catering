using Catering.DAL.Entities.FoodShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Interfaces
{
    public interface IFoodShopService 
    {
        public Task<IEnumerable<FoodShop>> GetFoodShops();

        public Task<FoodShop> GetFoodShop(int shopId);

        public Task AddFoodShop(FoodShop foodShop);

        public Task DeleteFoodShop(FoodShop foodShop);

        public Task UpdateFoodShop(FoodShop foodShop);
    }
}
