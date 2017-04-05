using System.Collections.Generic;
using Shared;
using WcfProxy.Service;

namespace WcfProxy
{
    public sealed class ServiceProxy : IServiceProxy
    {
        private readonly WebOperationContextWrapper _webOperationContextWrapper = new WebOperationContextWrapper();

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
