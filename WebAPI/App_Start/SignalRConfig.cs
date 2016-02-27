namespace DQC.Comics.WebAPI
{
    using Microsoft.Owin.Cors;
    using Owin;

    public static class SignalRConfig
    {
        public static void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                //map.UseCors(CorsOptions.AllowAll);
                map.RunSignalR();
            });
        }
    }
}
