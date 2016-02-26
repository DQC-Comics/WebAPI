namespace DQC.Comics.WebAPI.Models
{
    using System.Collections.Generic;

    public class ApiHeroBasic
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ApiHeroLimited : ApiHeroBasic
    {
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// Customer cost per hour
        /// </summary>
        public double DebitPrice { get; set; }

        public double Rating { get; set; }

        public double RatingCount { get; set; }

        public IEnumerable<ApiHeroSkill> Skills { get; set; }
    }

    public class ApiHeroDetails : ApiHeroLimited
    {
        /// <summary>
        /// Internal cost per hour
        /// </summary>
        public double InternalPrice { get; set; }
    }
}
