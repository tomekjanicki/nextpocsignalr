using Shared;

namespace Wcf.Code
{
    public class StoredWebOperationContext
    {
        private readonly WebContextData _data;

        public StoredWebOperationContext(WebContextData data)
        {
            _data = data;
        }

        public string GetCookieValue(string cookieName)
        {
            return !_data.CookiesIn.ContainsKey(cookieName.ToLower()) ? "" : _data.CookiesIn[cookieName.ToLower()];
        }

        public void AddCookie(string name, string value)
        {
            _data.CookiesOut[name.ToLower()] = value;
        }
    }
}