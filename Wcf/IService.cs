using System.ServiceModel;
using Shared;

namespace Wcf
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        WebContextData WhiteBoardV1AddItem(int item, int page, WebContextData data);

        [OperationContract]
        GetItemsV1 WhiteBoardV1GetItems(int page, WebContextData data);

        [OperationContract]
        GetPagesV1 WhiteBoardV1GetPages(WebContextData data);

        [OperationContract]
        WebContextData Login(string userName, string password, WebContextData data);

        [OperationContract]
        WebContextData Logout(WebContextData data);

        [OperationContract]
        WebContextData ShouldSendNotification(WebContextData data);
    }
}
