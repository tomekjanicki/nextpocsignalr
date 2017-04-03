using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace WebRealTime
{
    public sealed class WhiteBoardService : IWhiteBoardService
    {
        public void SendNewAddedItem(int item, int pageNumber)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<WhiteBoardHub>();
            hubContext.Clients.Group(pageNumber.ToString()).broadcastMessage(item, pageNumber);
        }

        public async Task JoinPage(int pageNumber)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<WhiteBoardHub>();
            await hubContext.Groups.Add("", pageNumber.ToString()).ConfigureAwait(false);
        }

        public Task LeavePage(int pageNumber)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<WhiteBoardHub>();
            return hubContext.Groups.Remove("", pageNumber.ToString());
        }
    }
}
