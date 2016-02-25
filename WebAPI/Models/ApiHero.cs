namespace DQC.Comics.WebAPI.Models
{
    public class ApiHeroLimited
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Color { get; set; }

        public double Rating { get; set; }

        public double RatingCount { get; set; }
    }

    public class ApiHeroDetails : ApiHeroLimited
    {
        /// <summary>
        /// Customer cost per hour
        /// </summary>
        public double DebitPrice { get; set; }

        /// <summary>
        /// Internal cost per hour
        /// </summary>
        public double InternalPrice { get; set; }
    }
}
