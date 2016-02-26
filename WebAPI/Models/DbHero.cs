namespace DQC.Comics.WebAPI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Heroes")]
    public class DbHero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// Customer cost per hour
        /// </summary>
        public double DebitPrice { get; set; }

        /// <summary>
        /// Internal cost per hour
        /// </summary>
        public double InternalPrice { get; set; }

        public double Rating { get; set; }

        public double RatingCount { get; set; }

        public virtual ICollection<DbHeroSkill> Skills { get; set; }
        
        public virtual ICollection<DbBooking> Bookings { get; set; }
    }
}
