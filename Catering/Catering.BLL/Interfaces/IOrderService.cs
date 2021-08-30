using Catering.DAL.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetOrders();

        public Task OrderIsPaid(int orderId, bool isPaid);

        public Task<Order> GetOrder(int orderId);

        public Task AddOrder(Order order);
    }
}
