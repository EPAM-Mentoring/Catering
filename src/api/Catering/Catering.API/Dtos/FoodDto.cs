using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos
{
    public class FoodDto
    {
        public int Id { get; set; }

        public string FoodName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int FoodShopId { get; set; }
    }
}
