namespace DQC.Comics.WebAPI
{
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;
    using DQC.Comics.WebAPI.Migrations;
    using DQC.Comics.WebAPI.Models;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComicsDbContext, Configuration>());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
