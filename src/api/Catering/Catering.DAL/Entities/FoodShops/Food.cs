using System;

namespace Catering.DAL.Entities.FoodShops
{
    public class Food : BaseEntity
    {
        public string FoodName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public FoodShop FoodShop { get; set; }
        public int FoodShopId { get; set; }

    }
}