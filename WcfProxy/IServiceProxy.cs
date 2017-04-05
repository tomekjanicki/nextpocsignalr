using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Shared;

namespace WcfProxy
{
    [ServiceContract]
    public interface IServiceProxy
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/WhiteBoardV2SaveChanges")]
        void WhiteBoardV2SaveChanges(int page);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/WhiteBoardV2GetSquares?page={page}")]
        IEnumerable<Square> WhiteBoardV2GetSquares(int page);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/WhiteBoardV2DeleteSquare")]
        void WhiteBoardV2DeleteSquare(Guid id, int page);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/WhiteBoardV2InsertSquare")]
        Guid WhiteBoardV2InsertSquare(int left, int top, int page);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/WhiteBoardV2UpdateSquare")]
        void WhiteBoardV2UpdateSquare(Square square, int page);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/WhiteBoardV2GetPages")]
        IEnumerable<int> WhiteBoardV2GetPages();

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
