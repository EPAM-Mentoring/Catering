using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Entities.Order
{
    public class Order : BaseEntity
    {
        public string PersonId { get; set; }

        public bool IsPaid { get; set; }

        public virtual ICollection<OrderItem> OrdersItems { get; set; }
           = new List<OrderItem>();

        public decimal Total() => OrdersItems.Sum(_ => _.FoodPrice * _.Quantity * _.MealPrice);
    }
}
