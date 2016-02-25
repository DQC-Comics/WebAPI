namespace DQC.Comics.WebAPI.Models
{
    public static class HeroExtensions
    {
        public static ApiHeroLimited ToApiHeroLimited(this Hero hero)
        {
            return new ApiHeroLimited
            {
                Id = hero.Id,
                Name = hero.Name,
                Description = hero.Description,
                ImageUrl = hero.ImageUrl,
                Color = hero.Color,
                Rating = hero.Rating,
                RatingCount = hero.RatingCount
            };
        }
    }
}