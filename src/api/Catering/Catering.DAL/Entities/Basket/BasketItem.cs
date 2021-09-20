namespace Catering.DAL.Entities.Basket
{
    public class BasketItem : BaseEntity
    {
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }

        public CustomerBasket CustomerBasket { get; set; }
        public int CustomerBasketId { get; set; }
    }
}