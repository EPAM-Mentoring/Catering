namespace Catering.DAL.Entities.Basket
{
    public class BasketItem 
    {
        public int Id { get; set; }

        public string FoodName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string PictureUrl { get; set; }
    }
}