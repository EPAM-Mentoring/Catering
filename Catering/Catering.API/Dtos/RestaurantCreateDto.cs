using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos
{
    public class RestaurantCreateDto
    {
        public string Name { get; set; }

        public ICollection<MealCreateDto> Meals { get; set; } = new List<MealCreateDto>();

        public DateTimeOffset OpenTime { get; set; }

        public DateTimeOffset ClosedTime { get; set; }
    }
}
