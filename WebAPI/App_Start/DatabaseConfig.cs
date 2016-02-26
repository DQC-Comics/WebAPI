namespace DQC.Comics.WebAPI
{
    using System.Data.Entity;
    using DQC.Comics.WebAPI.Migrations;
    using DQC.Comics.WebAPI.Models;

    public static class DatabaseConfig
    {
        public static void Configuration()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComicsDbContext, Configuration>());
        }
    }
}
