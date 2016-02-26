namespace DQC.Comics.WebAPI
{
    using Owin;

    public static class SignalRConfig
    {
        public static void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
