namespace DQC.Comics.WebAPI.Models
{
    using System;

    public class ApiHeroSearch
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Text { get; set; }
    }
}