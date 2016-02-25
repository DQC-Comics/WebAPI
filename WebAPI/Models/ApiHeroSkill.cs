namespace DQC.Comics.WebAPI.Models
{
    public class ApiHeroSkill
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Level { get; set; }

        public double Rating { get; set; }

        public double RatingCount { get; set; }
    }
}