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
        
        public string StreetAddress { get; set; }

        public Building Building { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }

        public ICollection<Food> Foods { get; set; }
            = new List<Food>();
    }
}
