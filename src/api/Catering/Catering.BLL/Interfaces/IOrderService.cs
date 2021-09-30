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
        Task<Order> CreateOrderAsync(string buyerEmail, int basketId);

        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);

        Task<Order> GetOrderByIdAsync(int id, string buyerEmail);
    }
}
