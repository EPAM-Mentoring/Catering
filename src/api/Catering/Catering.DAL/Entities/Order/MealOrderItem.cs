namespace Catering.DAL.Entities.Order
{
    public class MealOrderItem : BaseEntity
    {
        public MealOrderItem()
        {
        }

        public MealOrderItem( MealItemOrdered mealOrderd, decimal price, int quantity)
        {
            MealOrdered = mealOrderd;
            Price = price;
            Quantity = quantity;
        }

        public MealItemOrdered MealOrdered { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}