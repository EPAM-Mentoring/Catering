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

        public DateTimeOffset OpenTime { get; set; }

        public DateTimeOffset ClosedTime { get; set; }

        public ICollection<Meal> Meals { get; set; }
             = new List<Meal>();
        
        public Building Building { get; set; }
    }
}
