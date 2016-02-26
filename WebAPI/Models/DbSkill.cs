namespace DQC.Comics.WebAPI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Skills")]
    public class DbSkill
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }
    }
}