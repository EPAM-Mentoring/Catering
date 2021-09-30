using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Entities.Basket
{
    public class CustomerBasket : BaseEntity
    {
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public decimal ShippingPrice { get; set; }
    }
}
