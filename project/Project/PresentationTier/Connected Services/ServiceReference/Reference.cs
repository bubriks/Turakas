﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentationTier.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Chat", Namespace="http://schemas.datacontract.org/2004/07/DataTier")]
    [System.SerializableAttribute()]
    public partial class Chat : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool TypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateChat", ReplyAction="http://tempuri.org/IService/CreateChatResponse")]
        PresentationTier.ServiceReference.Chat CreateChat(PresentationTier.ServiceReference.Chat chat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateChat", ReplyAction="http://tempuri.org/IService/CreateChatResponse")]
        System.Threading.Tasks.Task<PresentationTier.ServiceReference.Chat> CreateChatAsync(PresentationTier.ServiceReference.Chat chat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetChat", ReplyAction="http://tempuri.org/IService/GetChatResponse")]
        PresentationTier.ServiceReference.Chat GetChat(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetChat", ReplyAction="http://tempuri.org/IService/GetChatResponse")]
        System.Threading.Tasks.Task<PresentationTier.ServiceReference.Chat> GetChatAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateChat", ReplyAction="http://tempuri.org/IService/UpdateChatResponse")]
        bool UpdateChat(PresentationTier.ServiceReference.Chat chat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateChat", ReplyAction="http://tempuri.org/IService/UpdateChatResponse")]
        System.Threading.Tasks.Task<bool> UpdateChatAsync(PresentationTier.ServiceReference.Chat chat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteChat", ReplyAction="http://tempuri.org/IService/DeleteChatResponse")]
        bool DeleteChat(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteChat", ReplyAction="http://tempuri.org/IService/DeleteChatResponse")]
        System.Threading.Tasks.Task<bool> DeleteChatAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPersonsInChat", ReplyAction="http://tempuri.org/IService/GetPersonsInChatResponse")]
        string GetPersonsInChat(int chatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPersonsInChat", ReplyAction="http://tempuri.org/IService/GetPersonsInChatResponse")]
        System.Threading.Tasks.Task<string> GetPersonsInChatAsync(int chatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddPersonToChat", ReplyAction="http://tempuri.org/IService/AddPersonToChatResponse")]
        bool AddPersonToChat(int chatId, int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddPersonToChat", ReplyAction="http://tempuri.org/IService/AddPersonToChatResponse")]
        System.Threading.Tasks.Task<bool> AddPersonToChatAsync(int chatId, int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RemovePersonFromChat", ReplyAction="http://tempuri.org/IService/RemovePersonFromChatResponse")]
        bool RemovePersonFromChat(int chatId, int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RemovePersonFromChat", ReplyAction="http://tempuri.org/IService/RemovePersonFromChatResponse")]
        System.Threading.Tasks.Task<bool> RemovePersonFromChatAsync(int chatId, int personId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : PresentationTier.ServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<PresentationTier.ServiceReference.IService>, PresentationTier.ServiceReference.IService {
        
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
        
        public PresentationTier.ServiceReference.Chat CreateChat(PresentationTier.ServiceReference.Chat chat) {
            return base.Channel.CreateChat(chat);
        }
        
        public System.Threading.Tasks.Task<PresentationTier.ServiceReference.Chat> CreateChatAsync(PresentationTier.ServiceReference.Chat chat) {
            return base.Channel.CreateChatAsync(chat);
        }
        
        public PresentationTier.ServiceReference.Chat GetChat(int id) {
            return base.Channel.GetChat(id);
        }
        
        public System.Threading.Tasks.Task<PresentationTier.ServiceReference.Chat> GetChatAsync(int id) {
            return base.Channel.GetChatAsync(id);
        }
        
        public bool UpdateChat(PresentationTier.ServiceReference.Chat chat) {
            return base.Channel.UpdateChat(chat);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateChatAsync(PresentationTier.ServiceReference.Chat chat) {
            return base.Channel.UpdateChatAsync(chat);
        }
        
        public bool DeleteChat(int id) {
            return base.Channel.DeleteChat(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteChatAsync(int id) {
            return base.Channel.DeleteChatAsync(id);
        }
        
        public string GetPersonsInChat(int chatId) {
            return base.Channel.GetPersonsInChat(chatId);
        }
        
        public System.Threading.Tasks.Task<string> GetPersonsInChatAsync(int chatId) {
            return base.Channel.GetPersonsInChatAsync(chatId);
        }
        
        public bool AddPersonToChat(int chatId, int personId) {
            return base.Channel.AddPersonToChat(chatId, personId);
        }
        
        public System.Threading.Tasks.Task<bool> AddPersonToChatAsync(int chatId, int personId) {
            return base.Channel.AddPersonToChatAsync(chatId, personId);
        }
        
        public bool RemovePersonFromChat(int chatId, int personId) {
            return base.Channel.RemovePersonFromChat(chatId, personId);
        }
        
        public System.Threading.Tasks.Task<bool> RemovePersonFromChatAsync(int chatId, int personId) {
            return base.Channel.RemovePersonFromChatAsync(chatId, personId);
        }
    }
}
