using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfProxy
{
    [ServiceContract]
    public interface IServiceProxy
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/WhiteBoardV1AddItem")]
        void WhiteBoardV1AddItem(int item, int page);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/WhiteBoardV1GetItems?page={page}")]
        IEnumerable<int> WhiteBoardV1GetItems(int page);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/WhiteBoardV1GetPages")]
        IEnumerable<int> WhiteBoardV1GetPages();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Login")]
        void Login(string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Logout")]
        void Logout();
    }


}
