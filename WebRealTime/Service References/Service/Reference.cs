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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardGetShape", ReplyAction="http://tempuri.org/IService/WhiteBoardGetShapeResponse")]
        Shared.GetShape WhiteBoardGetShape(int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardGetShape", ReplyAction="http://tempuri.org/IService/WhiteBoardGetShapeResponse")]
        System.Threading.Tasks.Task<Shared.GetShape> WhiteBoardGetShapeAsync(int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardUpdateShape", ReplyAction="http://tempuri.org/IService/WhiteBoardUpdateShapeResponse")]
        Shared.WebContextData WhiteBoardUpdateShape(int page, Shared.Shape shape, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardUpdateShape", ReplyAction="http://tempuri.org/IService/WhiteBoardUpdateShapeResponse")]
        System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardUpdateShapeAsync(int page, Shared.Shape shape, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardAddItem", ReplyAction="http://tempuri.org/IService/WhiteBoardAddItemResponse")]
        Shared.WebContextData WhiteBoardAddItem(int item, int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardAddItem", ReplyAction="http://tempuri.org/IService/WhiteBoardAddItemResponse")]
        System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardAddItemAsync(int item, int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardGetItems", ReplyAction="http://tempuri.org/IService/WhiteBoardGetItemsResponse")]
        Shared.GetItems WhiteBoardGetItems(int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardGetItems", ReplyAction="http://tempuri.org/IService/WhiteBoardGetItemsResponse")]
        System.Threading.Tasks.Task<Shared.GetItems> WhiteBoardGetItemsAsync(int page, Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardGetPages", ReplyAction="http://tempuri.org/IService/WhiteBoardGetPagesResponse")]
        Shared.GetPages WhiteBoardGetPages(Shared.WebContextData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/WhiteBoardGetPages", ReplyAction="http://tempuri.org/IService/WhiteBoardGetPagesResponse")]
        System.Threading.Tasks.Task<Shared.GetPages> WhiteBoardGetPagesAsync(Shared.WebContextData data);
        
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
        
        public Shared.GetShape WhiteBoardGetShape(int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardGetShape(page, data);
        }
        
        public System.Threading.Tasks.Task<Shared.GetShape> WhiteBoardGetShapeAsync(int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardGetShapeAsync(page, data);
        }
        
        public Shared.WebContextData WhiteBoardUpdateShape(int page, Shared.Shape shape, Shared.WebContextData data) {
            return base.Channel.WhiteBoardUpdateShape(page, shape, data);
        }
        
        public System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardUpdateShapeAsync(int page, Shared.Shape shape, Shared.WebContextData data) {
            return base.Channel.WhiteBoardUpdateShapeAsync(page, shape, data);
        }
        
        public Shared.WebContextData WhiteBoardAddItem(int item, int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardAddItem(item, page, data);
        }
        
        public System.Threading.Tasks.Task<Shared.WebContextData> WhiteBoardAddItemAsync(int item, int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardAddItemAsync(item, page, data);
        }
        
        public Shared.GetItems WhiteBoardGetItems(int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardGetItems(page, data);
        }
        
        public System.Threading.Tasks.Task<Shared.GetItems> WhiteBoardGetItemsAsync(int page, Shared.WebContextData data) {
            return base.Channel.WhiteBoardGetItemsAsync(page, data);
        }
        
        public Shared.GetPages WhiteBoardGetPages(Shared.WebContextData data) {
            return base.Channel.WhiteBoardGetPages(data);
        }
        
        public System.Threading.Tasks.Task<Shared.GetPages> WhiteBoardGetPagesAsync(Shared.WebContextData data) {
            return base.Channel.WhiteBoardGetPagesAsync(data);
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
