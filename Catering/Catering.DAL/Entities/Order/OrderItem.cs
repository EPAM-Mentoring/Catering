using Catering.DAL.Entities.FoodShop;
using Catering.DAL.Entities.Restaurnt;

namespace Catering.DAL.Entities.Order
{
    public class OrderItem : BaseEntity
    {
        public virtual Food Food { get; }

        public virtual Meal Meal { get;  }

        public decimal MealPrice { get; }

        public decimal FoodPrice { get;  }

        public int Quantity { get; }

        public OrderItem()
        {

        }

        public OrderItem(Food food, Meal meal, int quantity)
        {
            Food = food;
            Meal = meal;
            MealPrice = meal.Price;
            FoodPrice = meal.Price;
            Quantity = quantity;
        }
    }
}