﻿using System;
using Shared;
using Wcf.Code;

namespace Wcf
{
    public sealed class Service : IService
    {
        private readonly Authentication _authentication = new Authentication();
        private readonly Whiteboard _whiteboard = new Whiteboard();

        public WebContextData WhiteBoardAdd(int item, WebContextData data)
        {
            var sessionId = GetSessionId(data);
            var userName = _authentication.GetUserName(sessionId);
            _whiteboard.Add(item, userName);
            return data;
        }

        public WebContextData WhiteBoardEndEdit(WebContextData data)
        {
            var sessionId = GetSessionId(data);
            var userName = _authentication.GetUserName(sessionId);
            _whiteboard.EndEdit(userName);
            return data;
        }

        public GetItems WhiteBoardGetItems(WebContextData data)
        {
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            return new GetItems { Data = data, Items = _whiteboard.GetItems() };
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
            var sessionId = GetSessionId(data);
            _authentication.CheckSession(sessionId);
            _authentication.Logout(sessionId);
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
