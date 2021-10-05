using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Entities.Basket
{
    public class CustomerBasket : BaseEntity
    {
        public int? DeliveryMethodId { get; set; }
      
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public List<MealBasketItem> MealItems { get; set; } = new List<MealBasketItem>();

        public decimal ShippingPrice { get; set; }
    }
}
