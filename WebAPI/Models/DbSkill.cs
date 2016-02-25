namespace DQC.Comics.WebAPI.Models
{
    using System.Collections.Generic;

    public class DbSkill
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public virtual ICollection<DbBooking> Bookings { get; set; }
    }
}