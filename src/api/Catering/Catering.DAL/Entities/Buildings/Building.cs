using Catering.DAL.Entities.FoodShops;
using Catering.DAL.Entities.Restaurnt;
using System;

namespace Catering.DAL.Entities.Buildings
{
    public class Building : BaseEntity
    {
        public string Street { get; set; }

        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }

        public FoodShop FoodShop { get; set; }
        public int FoodShopId { get; set; }
    }
}
