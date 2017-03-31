using Microsoft.AspNet.SignalR;

namespace WebRealTime
{
    public sealed class WhiteBoardHub : Hub
    {
        public void SendNewAddedItem(string item)
        {
            Clients.All.broadcastMessage(item);
        }
    }
}