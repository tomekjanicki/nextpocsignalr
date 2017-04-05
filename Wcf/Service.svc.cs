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
        private readonly WhiteboardV2Proxy _whiteboardV2Proxy = new WhiteboardV2Proxy();

        public WebContextData WhiteBoardV2SaveChanges(int page, WebContextData data)
        {
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            _whiteboardV2Proxy.SaveChanges(page);
            return data;
        }

        public GetSquaresV2 WhiteBoardV2GetSquares(int page, WebContextData data)
        {
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            return new GetSquaresV2 { Data = data, Squares = _whiteboardV2Proxy.GetSquares(page) };
        }

        public WebContextData WhiteBoardV2DeleteSquare(Guid id, int page, WebContextData data)
        {
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            _whiteboardV2Proxy.DeleteSquare(page, id);
            return data;
        }

        public WebContextData WhiteBoardV2UpdateSquare(Square square, int page, WebContextData data)
        {
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            _whiteboardV2Proxy.UpdateSquare(page, square);
            return data;
        }

        public InsertSquareV2 WhiteBoardV2InsertSquare(double left, double top, int page, WebContextData data)
        {
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            var square = new Square { Id = Guid.NewGuid(), Left = left, Top = top };
            _whiteboardV2Proxy.UpdateSquare(page, square);
            return new InsertSquareV2 { Data = data, Id = square.Id };
        }

        public GetPagesV2 WhiteBoardV2GetPages(WebContextData data)
        {
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            return new GetPagesV2 { Data = data, Items = _whiteboardV2Proxy.GetPages() };
        }

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
