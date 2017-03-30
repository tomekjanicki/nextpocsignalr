using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using Shared;

namespace WcfProxy
{
    public sealed class WebOperationContextWrapper
    {
        public Dictionary<string, string> GetAllCookies()
        {
            var retDictionary = new Dictionary<string, string>();

            if (WebOperationContext.Current != null)
            {
                var cookieHeader = WebOperationContext.Current.IncomingRequest.Headers[HttpRequestHeader.Cookie];

                if (string.IsNullOrEmpty(cookieHeader))
                    return retDictionary;

                var cookies = cookieHeader.Split(';');
                for (var i = 0; i < cookies.Length; i++)
                {
                    cookies[i] = cookies[i].ToLower().Trim();

                    var tempCookie = cookies[i];

                    var parts = tempCookie.Split('=');

                    if (parts.Length == 2)
                    {
                        if (!retDictionary.ContainsKey(parts[0]))
                            retDictionary.Add(parts[0], parts[1]);
                    }
                }
            }

            return retDictionary;
        }

        public void UpdateContext(WebContextData data)
        {
            if (WebOperationContext.Current != null)
            {
                WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.SetCookie] = "";

                foreach (var cookie in data.CookiesOut.Keys)
                {
                    WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.SetCookie] = $"{cookie.ToLower()}={data.CookiesOut[cookie]}; path=/;";
                }
            }
        }
    }
}