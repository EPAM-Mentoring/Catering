using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos
{
    public class FoodShopCreateDto
    {
        public string Name { get; set; }

        public ICollection<FoodCreateDto> Foods { get; set; }
            = new List<FoodCreateDto>();
    }
}
