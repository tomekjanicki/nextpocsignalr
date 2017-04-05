﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebRealTime.Service {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Service.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV2SaveChanges", ReplyAction="http://tempuri.org/IService/WhiteBoardV2SaveChangesResponse")]
        Shared.WebContextData WhiteBoardV2SaveChanges(int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV2SaveChanges", ReplyAction="http://tempuri.org/IService/WhiteBoardV2SaveChangesResponse")]
        System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardV2SaveChangesAsync(int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV2GetSquares", ReplyAction="http://tempuri.org/IService/WhiteBoardV2GetSquaresResponse")]
        Shared.GetSquaresV2 WhiteBoardV2GetSquares(int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV2GetSquares", ReplyAction="http://tempuri.org/IService/WhiteBoardV2GetSquaresResponse")]
        System.Threading.Tasks.Task<Shared.GetSquaresV2> WhiteBoardV2GetSquaresAsync(int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV2DeleteSquare", ReplyAction="http://tempuri.org/IService/WhiteBoardV2DeleteSquareResponse")]
        Shared.WebContextData WhiteBoardV2DeleteSquare(System.Guid id, int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV2DeleteSquare", ReplyAction="http://tempuri.org/IService/WhiteBoardV2DeleteSquareResponse")]
        System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardV2DeleteSquareAsync(System.Guid id, int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV2InsertOrUpdateSquare", ReplyAction="http://tempuri.org/IService/WhiteBoardV2InsertOrUpdateSquareResponse")]
        Shared.WebContextData WhiteBoardV2InsertOrUpdateSquare(Shared.Square square, int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV2InsertOrUpdateSquare", ReplyAction="http://tempuri.org/IService/WhiteBoardV2InsertOrUpdateSquareResponse")]
        System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardV2InsertOrUpdateSquareAsync(Shared.Square square, int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV2GetPages", ReplyAction="http://tempuri.org/IService/WhiteBoardV2GetPagesResponse")]
        Shared.GetPagesV2 WhiteBoardV2GetPages(Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV2GetPages", ReplyAction="http://tempuri.org/IService/WhiteBoardV2GetPagesResponse")]
        System.Threading.Tasks.Task<Shared.GetPagesV2> WhiteBoardV2GetPagesAsync(Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV1AddItem", ReplyAction="http://tempuri.org/IService/WhiteBoardV1AddItemResponse")]
        Shared.WebContextData WhiteBoardV1AddItem(int item, int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV1AddItem", ReplyAction="http://tempuri.org/IService/WhiteBoardV1AddItemResponse")]
        System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardV1AddItemAsync(int item, int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV1GetItems", ReplyAction="http://tempuri.org/IService/WhiteBoardV1GetItemsResponse")]
        Shared.GetItemsV1 WhiteBoardV1GetItems(int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV1GetItems", ReplyAction="http://tempuri.org/IService/WhiteBoardV1GetItemsResponse")]
        System.Threading.Tasks.Task<Shared.GetItemsV1> WhiteBoardV1GetItemsAsync(int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV1GetPages", ReplyAction="http://tempuri.org/IService/WhiteBoardV1GetPagesResponse")]
        Shared.GetPagesV1 WhiteBoardV1GetPages(Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardV1GetPages", ReplyAction="http://tempuri.org/IService/WhiteBoardV1GetPagesResponse")]
        System.Threading.Tasks.Task<Shared.GetPagesV1> WhiteBoardV1GetPagesAsync(Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Login", ReplyAction="http://tempuri.org/IService/LoginResponse")]
        Shared.WebContextData Login(string userName, string password, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Login", ReplyAction="http://tempuri.org/IService/LoginResponse")]
        System.Threading.Tasks.Task<Shared.WebContextData> LoginAsync(string userName, string password, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Logout", ReplyAction="http://tempuri.org/IService/LogoutResponse")]
        Shared.WebContextData Logout(Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Logout", ReplyAction="http://tempuri.org/IService/LogoutResponse")]
        System.Threading.Tasks.Task<Shared.WebContextData> LogoutAsync(Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ShouldSendNotification", ReplyAction="http://tempuri.org/IService/ShouldSendNotificationResponse")]
        Shared.WebContextData ShouldSendNotification(Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ShouldSendNotification", ReplyAction="http://tempuri.org/IService/ShouldSendNotificationResponse")]
        System.Threading.Tasks.Task<Shared.WebContextData> ShouldSendNotificationAsync(Shared.WebContextData data);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : WebRealTime.Service.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<WebRealTime.Service.IService>, WebRealTime.Service.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Shared.WebContextData WhiteBoardV2SaveChanges(int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV2SaveChanges(page, data);
        }
        
        public System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardV2SaveChangesAsync(int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV2SaveChangesAsync(page, data);
        }
        
        public Shared.GetSquaresV2 WhiteBoardV2GetSquares(int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV2GetSquares(page, data);
        }
        
        public System.Threading.Tasks.Task<Shared.GetSquaresV2> WhiteBoardV2GetSquaresAsync(int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV2GetSquaresAsync(page, data);
        }
        
        public Shared.WebContextData WhiteBoardV2DeleteSquare(System.Guid id, int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV2DeleteSquare(id, page, data);
        }
        
        public System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardV2DeleteSquareAsync(System.Guid id, int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV2DeleteSquareAsync(id, page, data);
        }
        
        public Shared.WebContextData WhiteBoardV2InsertOrUpdateSquare(Shared.Square square, int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV2InsertOrUpdateSquare(square, page, data);
        }
        
        public System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardV2InsertOrUpdateSquareAsync(Shared.Square square, int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV2InsertOrUpdateSquareAsync(square, page, data);
        }
        
        public Shared.GetPagesV2 WhiteBoardV2GetPages(Shared.WebContextData data) {
            return base.Channel.WhiteBoardV2GetPages(data);
        }
        
        public System.Threading.Tasks.Task<Shared.GetPagesV2> WhiteBoardV2GetPagesAsync(Shared.WebContextData data) {
            return base.Channel.WhiteBoardV2GetPagesAsync(data);
        }
        
        public Shared.WebContextData WhiteBoardV1AddItem(int item, int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV1AddItem(item, page, data);
        }
        
        public System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardV1AddItemAsync(int item, int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV1AddItemAsync(item, page, data);
        }
        
        public Shared.GetItemsV1 WhiteBoardV1GetItems(int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV1GetItems(page, data);
        }
        
        public System.Threading.Tasks.Task<Shared.GetItemsV1> WhiteBoardV1GetItemsAsync(int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardV1GetItemsAsync(page, data);
        }
        
        public Shared.GetPagesV1 WhiteBoardV1GetPages(Shared.WebContextData data) {
            return base.Channel.WhiteBoardV1GetPages(data);
        }
        
        public System.Threading.Tasks.Task<Shared.GetPagesV1> WhiteBoardV1GetPagesAsync(Shared.WebContextData data) {
            return base.Channel.WhiteBoardV1GetPagesAsync(data);
        }
        
        public Shared.WebContextData Login(string userName, string password, Shared.WebContextData data) {
            return base.Channel.Login(userName, password, data);
        }
        
        public System.Threading.Tasks.Task<Shared.WebContextData> LoginAsync(string userName, string password, Shared.WebContextData data) {
            return base.Channel.LoginAsync(userName, password, data);
        }
        
        public Shared.WebContextData Logout(Shared.WebContextData data) {
            return base.Channel.Logout(data);
        }
        
        public System.Threading.Tasks.Task<Shared.WebContextData> LogoutAsync(Shared.WebContextData data) {
            return base.Channel.LogoutAsync(data);
        }
        
        public Shared.WebContextData ShouldSendNotification(Shared.WebContextData data) {
            return base.Channel.ShouldSendNotification(data);
        }
        
        public System.Threading.Tasks.Task<Shared.WebContextData> ShouldSendNotificationAsync(Shared.WebContextData data) {
            return base.Channel.ShouldSendNotificationAsync(data);
        }
    }
}
