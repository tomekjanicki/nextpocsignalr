using System.ServiceModel;
using Shared;

namespace Wcf
{
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        WebContextData WhiteBoardAdd(int item, int page, WebContextData data);

        [OperationContract]
        WebContextData WhiteBoardEndEdit(int page, WebContextData data);

        [OperationContract]
        GetItems WhiteBoardGetItems(int page, WebContextData data);

        [OperationContract]
        GetPages WhiteBoardGetPages(WebContextData data);

        [OperationContract]
        WebContextData Login(string userName, string password, WebContextData data);

        [OperationContract]
        WebContextData Logout(WebContextData data);

        [OperationContract]
        WebContextData ShouldSendNotification(WebContextData data);
    }
}
