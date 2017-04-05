using System;
using System.Diagnostics;
using Shared;
using Wcf.Code;

namespace Wcf
{
    public sealed class Service : IService
    {
        private readonly Authentication _authentication = new Authentication();
        private readonly WhiteboardV1 _whiteboardV1 = new WhiteboardV1();

        public WebContextData WhiteBoardV1AddItem(int item, int page, WebContextData data)
        {
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            _whiteboardV1.AddItem(item, page);
            return data;
        }

        public GetPagesV1 WhiteBoardV1GetPages(WebContextData data)
        {
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            return new GetPagesV1 { Data = data, Items = _whiteboardV1.GetPages() };
        }

        public GetItemsV1 WhiteBoardV1GetItems(int page, WebContextData data)
        {
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            return new GetItemsV1 { Data = data, Items = _whiteboardV1.GetItems(page) };
        }

        public WebContextData Login(string userName, string password, WebContextData data)
        {
            var sessionId = _authentication.Login(userName, password);
            var storedWebOperationContext = new StoredWebOperationContext(data);
            storedWebOperationContext.AddCookie("sessionId", sessionId.ToString());
            return data;
        }

        public WebContextData Logout(WebContextData data)
        {
            Debug.WriteLine("Logout called");
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            _authentication.Logout(sessionId);
            return data;
        }

        public WebContextData ShouldSendNotification(WebContextData data)
        {
            Debug.WriteLine("ShouldSendNotification called");
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            return data;
        }

        private static Guid GetSessionId(WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var sessionIdString = storedWebOperationContext.GetCookieValue("sessionId");
            return Guid.Parse(sessionIdString);
        }
    }
}
