using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Shared;
using WcfProxy.RealTime;
using WcfProxy.Service;

namespace WcfProxy
{
    public sealed class ServiceProxy : IServiceProxy
    {
        private readonly WebOperationContextWrapper _webOperationContextWrapper = new WebOperationContextWrapper();

        public async Task JoinPage(int page, string connectionId)
        {
            using (var client = new ServiceClient())
            {
                client.ShouldSendNotification(GetContextData());
            }
            var pageId = page.ToString();
            var context = GetHubContext();
            await context.Groups.Add(connectionId, pageId).ConfigureAwait(false);
        }

        public Task LeavePage(int page, string connectionId)
        {
            using (var client = new ServiceClient())
            {
                client.ShouldSendNotification(GetContextData());
            }
            var pageId = page.ToString();
            var context = GetHubContext();
            return context.Groups.Remove(connectionId, pageId);
        }

        public void WhiteBoardV2SaveChanges(int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2SaveChanges(page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data);
            }
        }

        public IEnumerable<Square> WhiteBoardV2GetSavedSquares(int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2GetSavedSquares(page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data.Data);
                return data.Squares;
            }
        }

        public IEnumerable<Square> WhiteBoardV2GetSquares(int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2GetSquares(page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data.Data);
                return data.Squares;
            }
        }

        public void WhiteBoardV2DeleteSquare(Guid id, int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2DeleteSquare(id, page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data);
            }
        }

        public void WhiteBoardV2DeleteSquareWithNotification(Guid id, int page, string connectionId)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2DeleteSquare(id, page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data);
                var context = GetHubContext();
                context.Clients.Group(page.ToString(), connectionId).SquareDeleted(id);
            }
        }

        public Guid WhiteBoardV2InsertSquare(int left, int top, int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2InsertSquare(left, top, page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data.Data);
                return data.Id;
            }
        }

        public Guid WhiteBoardV2InsertSquareWithNotification(int left, int top, int page, string connectionId)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2InsertSquare(left, top, page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data.Data);
                var context = GetHubContext();
                context.Clients.Group(page.ToString(), connectionId).SquareAdded(new Square { Id = data.Id, Left = left, Top = top });
                return data.Id;
            }
        }

        public void WhiteBoardV2UpdateSquare(Square square, int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2UpdateSquare(square, page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data);
            }
        }

        public void WhiteBoardV2UpdateSquareWithNotification(Square square, int page, string connectionId)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2UpdateSquare(square, page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data);
                var context = GetHubContext();
                context.Clients.Group(page.ToString(), connectionId).SquareMoved(square);
            }
        }

        public IEnumerable<int> WhiteBoardV2GetPages()
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2GetPages(GetContextData());
                _webOperationContextWrapper.UpdateContext(data.Data);
                return data.Items;
            }
        }

        public void WhiteBoardV1AddItem(int item, int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV1AddItem(item, page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data);
            }
        }

        public IEnumerable<int> WhiteBoardV1GetItems(int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV1GetItems(page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data.Data);
                return data.Items;
            }
        }

        public IEnumerable<int> WhiteBoardV1GetPages()
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV1GetPages(GetContextData());
                _webOperationContextWrapper.UpdateContext(data.Data);
                return data.Items;
            }
        }

        public void Login(string userName, string password)
        {
            using (var client = new ServiceClient())
            {
                var data = client.Login(userName, password, GetContextData());
                _webOperationContextWrapper.UpdateContext(data);
            }
        }

        public void Logout()
        {
            using (var client = new ServiceClient())
            {
                var data = client.Logout(GetContextData());
                _webOperationContextWrapper.UpdateContext(data);
            }
        }

        private WebContextData GetContextData()
        {
            return new WebContextData
            {
                CookiesIn = _webOperationContextWrapper.GetAllCookies()
            };
        }

        private static IHubContext<IClinetV2> GetHubContext()
        {
            return GlobalHost.ConnectionManager.GetHubContext<WhiteBoardHubV2, IClinetV2>();
        }

    }
}
