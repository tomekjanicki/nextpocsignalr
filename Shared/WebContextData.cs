using System.Collections.Generic;
using System.Net;

namespace Shared
{
    public class WebContextData
    {
        public Dictionary<string, string> CookiesIn = new Dictionary<string, string>();

        public Dictionary<string, string> CookiesOut = new Dictionary<string, string>();

        public HttpStatusCode StatusCode = HttpStatusCode.OK;

        public string StatusMessage = "";
    }
}