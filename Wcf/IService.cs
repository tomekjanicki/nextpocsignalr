using System;
using System.ServiceModel;
using Shared;

namespace Wcf
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        WebContextData WhiteBoardV2SaveChanges(int page, WebContextData data);

        [OperationContract]
        GetSquaresV2 WhiteBoardV2GetSavedSquares(int page, WebContextData data);

        [OperationContract]
        GetSquaresV2 WhiteBoardV2GetSquares(int page, WebContextData data);

        [OperationContract]
        WebContextData WhiteBoardV2DeleteSquare(Guid id, int page, WebContextData data);

        [OperationContract]
        WebContextData WhiteBoardV2UpdateSquare(Square square, int page, WebContextData data);

        [OperationContract]
        InsertSquareV2 WhiteBoardV2InsertSquare(int left, int top, int page, WebContextData data);

        [OperationContract]
        GetPagesV2 WhiteBoardV2GetPages(WebContextData data);

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
