using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace WebRealTime
{
    [ServiceContract]
    public interface IWhiteBoardService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/SendNewAddedItem")]
        void SendNewAddedItem(int item, int pageNumber);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/JoinPage")]
        Task JoinPage(int pageNumber);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/LeavePage")]
        Task LeavePage(int pageNumber);
    }
}