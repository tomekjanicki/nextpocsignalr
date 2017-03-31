using Microsoft.AspNet.SignalR;

namespace WebRealTime
{
    public sealed class WhiteBoardService : IWhiteBoardService
    {
        public void SendNewAddedItem(int item)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<WhiteBoardHub>();
            hubContext.Clients.All.broadcastMessage(item);
        }
    }
}
