using System;

namespace Catering.DAL.Entities.Restaurnt 
{
    public class Meal : BaseEntity
    {
        public string MealName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
    }
}