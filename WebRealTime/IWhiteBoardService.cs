using System.ServiceModel;
using System.ServiceModel.Web;

namespace WebRealTime
{
    [ServiceContract]
    public interface IWhiteBoardService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/SendNewAddedItem")]
        void SendNewAddedItem(int item);
    }


}