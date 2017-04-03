using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace WebRealTime
{
    public sealed class WhiteBoardHub : Hub
    {
        public void SendNewAddedItem(int item, int page)
        {
            var pageId = page.ToString();
            Clients.Group(pageId).broadcastMessage(item);
        }

        public async Task JoinPage(int page)
        {
            var pageId = page.ToString();
            await Groups.Add(Context.ConnectionId, pageId).ConfigureAwait(false);
        }

        public Task LeavePage(int page)
        {
            var pageId = page.ToString();
            return Groups.Remove(Context.ConnectionId, pageId);
        }
    }
}