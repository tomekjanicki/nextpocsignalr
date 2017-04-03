using System.ServiceModel;
using Shared;

namespace Wcf
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        GetShape WhiteBoardGetShape(int page, WebContextData data);

        [OperationContract]
        WebContextData WhiteBoardUpdateShape(int page, Shape shape, WebContextData data);

        [OperationContract]
        WebContextData WhiteBoardAddItem(int item, int page, WebContextData data);

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
