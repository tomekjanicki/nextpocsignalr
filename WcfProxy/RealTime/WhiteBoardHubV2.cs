using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Shared;

namespace WcfProxy.RealTime
{
    [MyAuthorize]
    public sealed class WhiteBoardHubV2 : Hub<IClinetV2>
    {
        public void SquareDelete(Guid id, int page)
        {
            var pageId = page.ToString();
            Clients.OthersInGroup(pageId).SquareDeleted(id);
        }

        public void SquareMove(Square square, int page)
        {
            var pageId = page.ToString();
            Clients.OthersInGroup(pageId).SquareMoved(square);
        }

        public void SquareAdd(Square square, int page)
        {
            var pageId = page.ToString();
            Clients.OthersInGroup(pageId).SquareAdded(square);
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