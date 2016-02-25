namespace DQC.Comics.WebAPI.Models
{
    public class HeroSkill
    {
        public int Id { get; set; }

        public virtual Hero Hero { get; set; }

        public virtual Skill Skill { get; set; }

        public double Level { get; set; }

        public double Rating { get; set; }

        public double RatingCount { get; set; }
    }
}