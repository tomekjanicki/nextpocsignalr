using System.Collections.Generic;
using Shared;
using WcfProxy.Service;

namespace WcfProxy
{
    public sealed class ServiceProxy : IServiceProxy
    {
        private readonly WebOperationContextWrapper _webOperationContextWrapper = new WebOperationContextWrapper();

        public void WhiteBoardAdd(int item, int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardAdd(item, page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data);
            }
        }

        public void WhiteBoardEndEdit(int pagex)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardEndEdit(pagex, GetContextData());
                _webOperationContextWrapper.UpdateContext(data);
            }
        }

        public IEnumerable<int> WhiteBoardGetItems(int page)
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardGetItems(page, GetContextData());
                _webOperationContextWrapper.UpdateContext(data.Data);
                return data.Items;
            }
        }

        public IEnumerable<int> WhiteBoardGetPages()
        {
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardGetPages(GetContextData());
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
