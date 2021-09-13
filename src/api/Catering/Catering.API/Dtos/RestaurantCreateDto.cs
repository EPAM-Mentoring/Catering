using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos
{
    public class RestaurantCreateDto
    {
        public string Name { get; set; }

        public string PictureUrl { get; set; }

        public DateTimeOffset OpenTime { get; set; }

        public DateTimeOffset ClosedTime { get; set; }
    }
}
