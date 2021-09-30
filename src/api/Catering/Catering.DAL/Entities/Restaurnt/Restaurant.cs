using Catering.DAL.Entities.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Entities.Restaurnt
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }

        public string PictureUrl { get; set; }

        public string StreetAddress { get; set; }

        public bool IsAvailableForBooking { get; set; }

        public decimal BookingPricePerDay { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }

        public ICollection<Meal> Meals { get; set; }
             = new List<Meal>();
        
        public Building Building { get; set; }
    }
}
