using System.ServiceModel;
using Shared;

namespace Wcf
{
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        WebContextData WhiteBoardAdd(int item, WebContextData data);

        [OperationContract]
        WebContextData WhiteBoardEndEdit(WebContextData data);

        [OperationContract]
        GetItems WhiteBoardGetItems(WebContextData data);

        [OperationContract]
        WebContextData Login(string userName, string password, WebContextData data);

        [OperationContract]
        WebContextData Logout(WebContextData data);
    }
}
