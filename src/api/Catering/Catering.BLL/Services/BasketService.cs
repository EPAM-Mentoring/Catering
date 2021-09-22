using Catering.BLL.Interfaces;
using Catering.DAL;
using Catering.DAL.Entities.Basket;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Services
{
    public class BasketService : BaseService, IBasketService
    {
        private IRepository<CustomerBasket> _repository;

        public BasketService(IUnitOfWork unitOfWork, 
            IRepository<CustomerBasket> repository) : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task<CustomerBasket> GetBasketAsync(int basketId)
        {
            return await _repository.GetAsync(basketId);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            _repository.Update(basket);
            try
            {
                await UnitOfWork.SaveChangeAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

            }

            return basket;
        }

        public async Task DeleteBasketAsync(CustomerBasket basket)
        {
            _repository.Delete(basket);
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
