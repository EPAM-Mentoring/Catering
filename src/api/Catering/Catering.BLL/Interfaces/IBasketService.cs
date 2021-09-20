using Catering.DAL.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Interfaces
{
    public interface IBasketService
    {
        public Task<CustomerBasket> GetBasketAsync(int basketId);

        public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        public Task DeleteBasketAsync(CustomerBasket basket);
    }
}
