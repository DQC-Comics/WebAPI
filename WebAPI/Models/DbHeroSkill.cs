namespace DQC.Comics.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HeroSkills")]
    public class DbHeroSkill
    {
        public int Id { get; set; }

        public virtual DbHero Hero { get; set; }

        public virtual DbSkill Skill { get; set; }

        public double Level { get; set; }

        public double Rating { get; set; }

        public double RatingCount { get; set; }
    }
}