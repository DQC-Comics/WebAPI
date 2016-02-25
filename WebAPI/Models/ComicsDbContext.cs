namespace DQC.Comics.WebAPI.Models
{
    using System.Data.Entity;

    public class ComicsDbContext : DbContext
    {
        public ComicsDbContext()
            : base("ComicsConnection")
        {
        }

        public DbSet<DbHero> Heroes { get; set; }

        public DbSet<DbSkill> Skills { get; set; }

        public DbSet<DbBooking> Bookings { get; set; }
    }
}
