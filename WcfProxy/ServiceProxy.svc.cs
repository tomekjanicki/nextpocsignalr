using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Shared;
using WcfProxy.RealTime;
using WcfProxy.Service;

namespace WcfProxy
{
    public sealed class ServiceProxy : IServiceProxy
    {
        private readonly WebOperationContextWrapper _webOperationContextWrapper = new WebOperationContextWrapper();

        public void WhiteBoardV2SaveChanges(int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2SaveChanges(page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data);
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

        public Guid WhiteBoardV2InsertSquare(int left, int top, int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2InsertSquare(left, top, page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data.Data);
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
    }
}
