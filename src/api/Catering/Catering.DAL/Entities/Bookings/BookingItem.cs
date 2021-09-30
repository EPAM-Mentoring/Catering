using System;

namespace Catering.DAL.Entities.Bookings
{
    public class BookingItem : BaseEntity
    {
        public BookingItem()
        {

        }

        public BookingItem(RestaurantBooked restaurantBooked, DateTimeOffset openTime, DateTimeOffset closedTime)
        {

        }

        public RestaurantBooked ResBooked { get; set; }

        public DateTimeOffset OpenTime { get; set; }

        public DateTimeOffset ClosedTime { get; set; }
    }
}