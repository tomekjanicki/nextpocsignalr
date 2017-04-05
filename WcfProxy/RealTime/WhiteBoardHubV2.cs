using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Shared;
using WcfProxy.Service;

namespace WcfProxy.RealTime
{
    public sealed class WhiteBoardHubV2 : Hub<IClinetV2>
    {
        public void SquareDelete(Guid id, int page)
        {
            CheckSecurity();
            var pageId = page.ToString();
            Clients.Group(pageId, Context.ConnectionId).SquareDeleted(id);
        }

        public void SquareMove(Square square, int page)
        {
            CheckSecurity();
            var pageId = page.ToString();
            Clients.Group(pageId, Context.ConnectionId).SquareMoved(square);
        }

        public void SquareAdd(Square square, int page)
        {
            CheckSecurity();
            var pageId = page.ToString();
            Clients.Group(pageId, Context.ConnectionId).SquareAdded(square);
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