namespace DQC.Comics.WebAPI.Models
{
    public static class BookingExtensions
    {
        public static ApiBooking ToApiBooking(this DbBooking booking)
        {
            return new ApiBooking
            {
                Id = booking.Id,
                Description = booking.Description
            };
        }

        public static DbBooking ToDbBooking(this ApiBooking booking)
        {
            return new DbBooking
            {
                Description = booking.Description
            };
        }
    }
}
