namespace DQC.Comics.WebAPI.Models
{
    using System.Linq;

    public static class BookingExtensions
    {
        public static ApiBooking ToApiBooking(this DbBooking booking)
        {
            return new ApiBooking
            {
                Id = booking.Id,
                CustomerId = booking.CustomerId,
                Description = booking.Description,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime,
                Location = booking.Location,
                City = booking.City,
                Country = booking.Country,
                CustomerRating = booking.CustomerRating,
                Status = booking.Status,
                Heroes = booking.Heroes?.Select(HeroExtensions.ToApiHeroBasic) ?? new ApiHeroBasic[0]
            };
        }

        public static DbBooking ToDbBooking(this ApiBooking booking)
        {
            return new DbBooking
            {
                Id = booking.Id,
                CustomerId = booking.CustomerId,
                Description = booking.Description,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime,
                Location = booking.Location,
                City = booking.City,
                Country = booking.Country,
                CustomerRating = booking.CustomerRating,
                Status = booking.Status,
                Heroes = new DbHero[0]
            };
        }
    }
}
