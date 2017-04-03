using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Shared;
using WebRealTime.Service;

namespace WebRealTime
{
    public sealed class WhiteBoardHub : Hub<IClient>
    {
        public void SendNewAddedItem(int item, int page)
        {
            CheckSecurity();
            var pageId = page.ToString();
            Clients.Group(pageId).BroadcastMessage(item);
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
                client.ShouldSendNotification(GetContextData(Context.RequestCookies));
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