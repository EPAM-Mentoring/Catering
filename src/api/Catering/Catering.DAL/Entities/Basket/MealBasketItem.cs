using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Entities.Basket
{
    public class MealBasketItem 
    {
        public int Id { get; set; }

        public string MealName { get; set; }

        public decimal MealPrice { get; set; }

        public int MealQuantity { get; set; }

        public string MealPictureUrl { get; set; }
    }
}
