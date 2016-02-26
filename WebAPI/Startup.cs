using System.Web.Http;
using DQC.Comics.WebAPI;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("Configuration", typeof(Startup))]

namespace DQC.Comics.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DatabaseConfig.Configuration();
            SignalRConfig.Configuration(app);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
