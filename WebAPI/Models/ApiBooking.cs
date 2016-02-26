﻿namespace DQC.Comics.WebAPI.Models
{
    using System;
    using System.Collections.Generic;

    public class ApiBooking
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        public double CustomerRating { get; set; }

        public double CustomerRatingCount { get; set; }

        public ICollection<ApiHeroBasic> Heroes { get; set; }
    }
}
