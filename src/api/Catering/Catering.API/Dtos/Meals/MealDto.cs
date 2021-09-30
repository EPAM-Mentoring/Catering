using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos
{
    public class MealDto
    {
        public int Id { get; set; }

        public string MealName { get; set; }
        
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int RestaurantId { get; set; }
    }
}
