namespace DQC.Comics.WebAPI.Models
{
    using System;
    using System.Collections.Generic;

    public class Booking
    {
        public int Id { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// The heroes involved in the booking
        /// </summary>
        public virtual ICollection<Hero> Heroes { get; set; }

        /// <summary>
        /// The skills involved in the booking
        /// </summary>
        public virtual ICollection<Skill> Skills { get; set; }

        public double CustomerRating { get; set; }

        public double CustomerRatingCount { get; set; }

        public double HeroRating { get; set; }

        public double CustomerHeroRating { get; set; }

        public double TotalDebitPrice { get; set; }

        public double TotalInternalPrice { get; set; }

        /// <summary>
        /// Hours debited to customer
        /// </summary>
        public double DebitHours { get; set; }

        /// <summary>
        /// Actual hours spent by the hero
        /// </summary>
        public double ActualHours { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location { get; set; }
    }
}