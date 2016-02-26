namespace DQC.Comics.WebAPI.Models
{
    using System.Linq;

    public static class HeroExtensions
    {
        public static ApiHeroLimited ToApiHeroLimited(this DbHero hero)
        {
            return new ApiHeroLimited
            {
                Id = hero.Id,
                Name = hero.Name,
                Description = hero.Description,
                ImageUrl = hero.ImageUrl,
                Color = hero.Color,
                DebitPrice = hero.DebitPrice,
                Rating = hero.Rating,
                RatingCount = hero.RatingCount,
                Skills = hero.Skills?.Select(ToApiHeroSkill) ?? new ApiHeroSkill[0]
            };
        }

        public static ApiHeroSkill ToApiHeroSkill(this DbHeroSkill skill)
        {
            return new ApiHeroSkill
            {
                Id = skill.Id,
                Name = skill.Skill.Name,
                Description = skill.Skill.Description,
                Level = skill.Level,
                Rating = skill.Rating,
                RatingCount = skill.RatingCount
            };
        }
    }
}
