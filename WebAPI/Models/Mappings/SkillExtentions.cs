namespace DQC.Comics.WebAPI.Models
{
    public static class SkillExtentions
    {
        public static ApiSkill ToApiSkill(this DbSkill skill)
        {
            return new ApiSkill
            {
                Id = skill.Id,
                Name = skill.Name,
                Description = skill.Description
            };
        }
    }
}
