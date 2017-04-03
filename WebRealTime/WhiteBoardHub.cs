using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace WebRealTime
{
    public sealed class WhiteBoardHub : Hub
    {
        public void SendNewAddedItem(int item, int page)
        {
            CheckSecurity();
            var pageId = page.ToString();
            Clients.Group(pageId).broadcastMessage(item);
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
            if (Context.RequestCookies.ContainsKey("sessionId"))
            {
                return;
            }

            throw new InvalidOperationException();
        }
    }
}