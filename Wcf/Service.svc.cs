using System;
using System.Diagnostics;
using System.Net;
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
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
                return data;
            }

            _whiteboardV2Proxy.SaveChanges(page);
            return data;
        }

        public GetSquaresV2 WhiteBoardV2GetSavedSquares(int page, WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
                return new GetSquaresV2 { Data = data };
            }

            return new GetSquaresV2 { Data = data, Squares = _whiteboardV2Proxy.GetSavedSquares(page) };
        }

        public GetSquaresV2 WhiteBoardV2GetSquares(int page, WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
                return new GetSquaresV2 { Data = data };
            }

            return new GetSquaresV2 { Data = data, Squares = _whiteboardV2Proxy.GetSquares(page) };
        }

        public WebContextData WhiteBoardV2DeleteSquare(Guid id, int page, WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
                return data;
            }

            _whiteboardV2Proxy.DeleteSquare(page, id);
            return data;
        }

        public WebContextData WhiteBoardV2UpdateSquare(Square square, int page, WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
                return data;
            }

            _whiteboardV2Proxy.UpdateSquare(page, square);
            return data;
        }

        public InsertSquareV2 WhiteBoardV2InsertSquare(int left, int top, int page, WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
                return new InsertSquareV2 { Data = data };
            }

            var square = new Square { Id = Guid.NewGuid(), Left = left, Top = top };
            _whiteboardV2Proxy.UpdateSquare(page, square);
            return new InsertSquareV2 { Data = data, Id = square.Id };
        }

        public GetPagesV2 WhiteBoardV2GetPages(WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
                return new GetPagesV2 { Data = data };
            }

            return new GetPagesV2 { Data = data, Items = _whiteboardV2Proxy.GetPages() };
        }

        public WebContextData WhiteBoardV1AddItem(int item, int page, WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
                return data;
            }

            _whiteboardV1.AddItem(item, page);
            return data;
        }

        public GetPagesV1 WhiteBoardV1GetPages(WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
                return new GetPagesV1 { Data = data };
            }

            return new GetPagesV1 { Data = data, Items = _whiteboardV1.GetPages() };
        }

        public GetItemsV1 WhiteBoardV1GetItems(int page, WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
                return new GetItemsV1 { Data = data };
            }

            return new GetItemsV1 { Data = data, Items = _whiteboardV1.GetItems(page) };
        }

        public WebContextData Login(string userName, string password, WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.BadRequest, "Wrong userName/password");
                return data;
            }

            var sessionId = _authentication.Login(userName, password);

            if (sessionId == null)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Unauthorized, "User not exists or wrong userName/password");
                return data;
            }

            storedWebOperationContext.AddCookie("sessionId", sessionId.Value.ToString());
            return data;
        }

        public WebContextData Logout(WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
                return data;
            }

            var sessionId = GetSessionId(storedWebOperationContext);
            Debug.Assert(sessionId != null, $"{nameof(sessionId)} != null");
            _authentication.Logout(sessionId.Value);
            return data;
        }

        public WebContextData ShouldSendNotification(WebContextData data)
        {
            var storedWebOperationContext = new StoredWebOperationContext(data);
            var shouldContinue = ShouldContinue(storedWebOperationContext);
            if (!shouldContinue)
            {
                storedWebOperationContext.ReturnStatusCode(HttpStatusCode.Forbidden, "");
            }
            return data;
        }

        private static Guid? GetSessionId(StoredWebOperationContext context)
        {            
            var sessionIdString = context.GetCookieValue("sessionId");
            Guid guid;
            return Guid.TryParse(sessionIdString, out guid) ? (Guid?) guid : null;
        }

        private bool ShouldContinue(StoredWebOperationContext context)
        {
            var sessionId = GetSessionId(context);

            return sessionId != null && _authentication.SessionExists(sessionId.Value);
        }
    }
}
