namespace DQC.Comics.WebAPI.Models
{
    using System.Collections.Generic;

    public class Skill
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}