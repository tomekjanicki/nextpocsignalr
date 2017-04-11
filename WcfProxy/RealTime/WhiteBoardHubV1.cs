using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Shared;
using WcfProxy.Service;
using Cookie = Microsoft.AspNet.SignalR.Cookie;

namespace WcfProxy.RealTime
{
    public sealed class WhiteBoardHubV1 : Hub<IClientV1>
    {
        public void SendNewItemAdded(int item, int page)
        {
            CheckSecurity();
            var pageId = page.ToString();
            Clients.Group(pageId).NewItemAdded(item);
        }

        public async Task JoinPage(int page)
        {
            CheckSecurity();
            var pageId = page.ToString();
            await Groups.Add(Context.ConnectionId, pageId).ConfigureAwait(false);
        }

        public Task LeavePage(int page)
        {
            CheckSecurity();
            var pageId = page.ToString();
            return Groups.Remove(Context.ConnectionId, pageId);
        }

        private void CheckSecurity()
        {
            using (var client = new ServiceClient())
            {
                var data = client.ShouldSendNotification(GetContextData(Context.RequestCookies));
                if (data.StatusCode != HttpStatusCode.OK)
                {
                    throw new InvalidOperationException();
                }
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
