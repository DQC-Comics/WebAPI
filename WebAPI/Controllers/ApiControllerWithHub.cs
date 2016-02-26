namespace DQC.Comics.WebAPI.Controllers
{
    using System;
    using System.Web.Http;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    public abstract class ApiControllerWithHub<THub> : ApiController
    where THub : IHub
    {
        private readonly Lazy<IHubContext> hub = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<THub>());

        protected IHubContext Hub => this.hub.Value;
    }
}
