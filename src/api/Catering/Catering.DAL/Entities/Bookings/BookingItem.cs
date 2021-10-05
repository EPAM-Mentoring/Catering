using System;

namespace Catering.DAL.Entities.Bookings
{
    public class BookingItem : BaseEntity
    {
        public BookingItem()
        {

        }

        public BookingItem(RestaurantBooked restaurantBooked, TimeSpan openTime, TimeSpan closedTime)
        {
            ResBooked = restaurantBooked;
            OpenTime = openTime;
            ClosedTime = closedTime;
        }

        public RestaurantBooked ResBooked { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan ClosedTime { get; set; }
    }
}