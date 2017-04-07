using Microsoft.AspNet.SignalR;
using Owin;

namespace WcfProxy
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.MapSignalR(new HubConfiguration
            {
                EnableDetailedErrors = true
            });
        }
    }
}