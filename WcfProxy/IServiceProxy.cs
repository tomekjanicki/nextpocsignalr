using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfProxy
{
    [ServiceContract]
    public interface IServiceProxy
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/WhiteBoardAddItem")]
        void WhiteBoardAddItem(int item, int page);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/WhiteBoardGetItems?page={page}")]
        IEnumerable<int> WhiteBoardGetItems(int page);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/WhiteBoardGetPages")]
        IEnumerable<int> WhiteBoardGetPages();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Login")]
        void Login(string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Logout")]
        void Logout();
    }


}
