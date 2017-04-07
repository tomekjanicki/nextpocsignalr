using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Shared;
using WcfProxy.Service;

namespace WcfProxy.RealTime
{
    public sealed class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public override bool AuthorizeHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
        {
            return CheckSecurity(hubIncomingInvokerContext.Hub.Context);
        }

        public override bool AuthorizeHubConnection(HubDescriptor hubDescriptor, IRequest request)
        {
            return true;
        }

        private static bool CheckSecurity(HubCallerContext hubCallerContext)
        {
            try
            {
                using (var client = new ServiceClient())
                {
                    client.ShouldSendNotification(GetContextData(hubCallerContext.RequestCookies));
                    return true;
                }
            }
            catch (FaultException)
            {
                return false;
            }
        }

        private static WebContextData GetContextData(IDictionary<string, Cookie> cookies)
        {
            return new WebContextData
            {
                CookiesIn = cookies.ToDictionary(pair => pair.Value.Name, pair => pair.Value.Value.ToString())
            };
        }

    }
}