using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Entities.Order
{
    public class MealItemOrdered
    {
        public MealItemOrdered()
        {
        }

        public MealItemOrdered(int mealItemId, string mealName, string mealPictureUrl)
        {
            MealItemId = mealItemId;
            MealName = mealName;
            MealPictureUrl = mealPictureUrl;
        }

        public int MealItemId { get; set; }
        public string MealName { get; set; }
        public string MealPictureUrl { get; set; }
    }
}
