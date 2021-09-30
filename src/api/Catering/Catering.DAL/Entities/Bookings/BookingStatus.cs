using System.Runtime.Serialization;

namespace Catering.DAL.Entities.Bookings
{
    public enum BookingStatus
    {
        [EnumMember(Value = "BookingPending")]
        BookingPending,

        [EnumMember(Value = "BookingReceived")]
        BookingReceived,

        [EnumMember(Value = "BookingFailed")]
        BookingFailed
    }
}