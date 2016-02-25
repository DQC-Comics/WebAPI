namespace DQC.Comics.WebAPI.Models
{
    using System.Data.Entity;

    public class ComicsDbContext : DbContext
    {
        public ComicsDbContext()
            : base("ComicsConnection")
        {
        }

        public DbSet<Hero> Heroes { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
