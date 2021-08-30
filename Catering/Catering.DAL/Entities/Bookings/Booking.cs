using Catering.DAL.Entities.Restaurnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Entities.Bookings
{
    public class Booking : BaseEntity
    {
        public Restaurant Restaurant { get; }
        public int RestaurantId { get; set; }

        public string PersonId { get; set; }

        public bool IsAviable { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }
    }
}
