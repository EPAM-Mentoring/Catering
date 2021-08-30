namespace Catering.API.Dtos.Order
{
    public  class OrderItemDto
    {
        public int FoodId { get; set; }

        public int MealId { get; set; }

        public decimal MealPrice { get; set; }

        public decimal FoodPrice { get; set; }

        public int Quantity { get; set; }
    }
}