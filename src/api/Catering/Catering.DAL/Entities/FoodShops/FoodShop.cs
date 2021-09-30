using Catering.DAL.Entities.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Entities.FoodShops 
{
    public class FoodShop : BaseEntity
    {
        public string Name { get; set; }

        public string PictureUrl { get; set; } 

        public ICollection<Food> Foods { get; set; }
            = new List<Food>();

        public Building Building { get; set; }

        public DateTimeOffset OpenTime { get; set; }

        public DateTimeOffset ClosedTime { get; set; }
    }
}
