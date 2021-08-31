using Catering.BLL.Interfaces;
using Catering.DAL;
using Catering.DAL.DbContexts;
using Catering.DAL.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Services
{
    public class OrderService: BaseService, IOrderService
    {
        private readonly IRepository<Order> _repository;

        public OrderService(IRepository<Order> repository,
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task AddOrder(Order order)
        {
            _repository.Add(order);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task<Order> GetOrder(int orderId)
        {
            return await _repository.GetAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _repository.GetListAsync();
        }

        public async Task OrderIsPaid(int orderId, bool isPaid)
        {
            var order = await _repository.GetAsync(orderId);

            order.IsPaid = isPaid;

            _repository.Update(order);
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
