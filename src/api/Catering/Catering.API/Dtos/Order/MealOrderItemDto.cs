namespace Catering.API.Dtos.Order
{
    public class MealOrderItemDto
    {
        public int MealId { get; set; }

        public string MealName { get; set; }

        public string MealPictureUrl { get; set; }

        public decimal MealPrice { get; set; }

        public int MealQuantity { get; set; }
    }
}