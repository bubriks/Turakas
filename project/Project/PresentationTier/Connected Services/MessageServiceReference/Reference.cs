﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentationTier.MessageServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/DataTier")]
    [System.SerializableAttribute()]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreatorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CreatorIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
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
        public string Creator {
            get {
                return this.CreatorField;
            }
            set {
                if ((object.ReferenceEquals(this.CreatorField, value) != true)) {
                    this.CreatorField = value;
                    this.RaisePropertyChanged("Creator");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CreatorId {
            get {
                return this.CreatorIdField;
            }
            set {
                if ((this.CreatorIdField.Equals(value) != true)) {
                    this.CreatorIdField = value;
                    this.RaisePropertyChanged("CreatorId");
                }
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
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Profile", Namespace="http://schemas.datacontract.org/2004/07/DataTier")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Tuple<PresentationTier.MessageServiceReference.Profile, object, string>[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Tuple<PresentationTier.MessageServiceReference.Profile, object, string>))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PresentationTier.MessageServiceReference.Message))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PresentationTier.MessageServiceReference.Profile[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PresentationTier.MessageServiceReference.Chat))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PresentationTier.MessageServiceReference.Message[]))]
    public partial class Profile : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object CallBackField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NicknameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProfileIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
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
        public object CallBack {
            get {
                return this.CallBackField;
            }
            set {
                if ((object.ReferenceEquals(this.CallBackField, value) != true)) {
                    this.CallBackField = value;
                    this.RaisePropertyChanged("CallBack");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nickname {
            get {
                return this.NicknameField;
            }
            set {
                if ((object.ReferenceEquals(this.NicknameField, value) != true)) {
                    this.NicknameField = value;
                    this.RaisePropertyChanged("Nickname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProfileID {
            get {
                return this.ProfileIDField;
            }
            set {
                if ((this.ProfileIDField.Equals(value) != true)) {
                    this.ProfileIDField = value;
                    this.RaisePropertyChanged("ProfileID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
        private int MaxNrOfUsersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OwnerIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Tuple<PresentationTier.MessageServiceReference.Profile, object, string>[] UsersField;
        
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
        public int MaxNrOfUsers {
            get {
                return this.MaxNrOfUsersField;
            }
            set {
                if ((this.MaxNrOfUsersField.Equals(value) != true)) {
                    this.MaxNrOfUsersField = value;
                    this.RaisePropertyChanged("MaxNrOfUsers");
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
        public int OwnerID {
            get {
                return this.OwnerIDField;
            }
            set {
                if ((this.OwnerIDField.Equals(value) != true)) {
                    this.OwnerIDField = value;
                    this.RaisePropertyChanged("OwnerID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Tuple<PresentationTier.MessageServiceReference.Profile, object, string>[] Users {
            get {
                return this.UsersField;
            }
            set {
                if ((object.ReferenceEquals(this.UsersField, value) != true)) {
                    this.UsersField = value;
                    this.RaisePropertyChanged("Users");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MessageServiceReference.IMessageService", CallbackContract=typeof(PresentationTier.MessageServiceReference.IMessageServiceCallback))]
    public interface IMessageService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/JoinChat")]
        void JoinChat(int chatId, int profileId, string clientId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/JoinChat")]
        System.Threading.Tasks.Task JoinChatAsync(int chatId, int profileId, string clientId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/LeaveChat")]
        void LeaveChat(int chatId, int profileId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/LeaveChat")]
        System.Threading.Tasks.Task LeaveChatAsync(int chatId, int profileId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/InviteToChat")]
        void InviteToChat(int chatId, string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/InviteToChat")]
        System.Threading.Tasks.Task InviteToChatAsync(int chatId, string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/Writing")]
        void Writing(int chatId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/Writing")]
        System.Threading.Tasks.Task WritingAsync(int chatId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/CreateMessage")]
        void CreateMessage(int profileId, string text, int chatId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/CreateMessage")]
        System.Threading.Tasks.Task CreateMessageAsync(int profileId, string text, int chatId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/DeleteMessage")]
        void DeleteMessage(int profileId, int id, int chatId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/DeleteMessage")]
        System.Threading.Tasks.Task DeleteMessageAsync(int profileId, int id, int chatId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMessageServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/WritingMessage")]
        void WritingMessage(string clientId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/AddMessage")]
        void AddMessage(PresentationTier.MessageServiceReference.Message message, string clientId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/RemoveMessage")]
        void RemoveMessage(int id, string clientId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/Invite")]
        void Invite(bool result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/GetOnlineProfiles")]
        void GetOnlineProfiles(PresentationTier.MessageServiceReference.Profile[] profiles, string clientId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/GetChat")]
        void GetChat(PresentationTier.MessageServiceReference.Chat chat, string clientId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/GetMessages")]
        void GetMessages(PresentationTier.MessageServiceReference.Message[] messages, string clientId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessageService/Show")]
        void Show(bool result, string clientId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMessageServiceChannel : PresentationTier.MessageServiceReference.IMessageService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MessageServiceClient : System.ServiceModel.DuplexClientBase<PresentationTier.MessageServiceReference.IMessageService>, PresentationTier.MessageServiceReference.IMessageService {
        
        public MessageServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public MessageServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public MessageServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MessageServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MessageServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void JoinChat(int chatId, int profileId, string clientId) {
            base.Channel.JoinChat(chatId, profileId, clientId);
        }
        
        public System.Threading.Tasks.Task JoinChatAsync(int chatId, int profileId, string clientId) {
            return base.Channel.JoinChatAsync(chatId, profileId, clientId);
        }
        
        public void LeaveChat(int chatId, int profileId) {
            base.Channel.LeaveChat(chatId, profileId);
        }
        
        public System.Threading.Tasks.Task LeaveChatAsync(int chatId, int profileId) {
            return base.Channel.LeaveChatAsync(chatId, profileId);
        }
        
        public void InviteToChat(int chatId, string name) {
            base.Channel.InviteToChat(chatId, name);
        }
        
        public System.Threading.Tasks.Task InviteToChatAsync(int chatId, string name) {
            return base.Channel.InviteToChatAsync(chatId, name);
        }
        
        public void Writing(int chatId) {
            base.Channel.Writing(chatId);
        }
        
        public System.Threading.Tasks.Task WritingAsync(int chatId) {
            return base.Channel.WritingAsync(chatId);
        }
        
        public void CreateMessage(int profileId, string text, int chatId) {
            base.Channel.CreateMessage(profileId, text, chatId);
        }
        
        public System.Threading.Tasks.Task CreateMessageAsync(int profileId, string text, int chatId) {
            return base.Channel.CreateMessageAsync(profileId, text, chatId);
        }
        
        public void DeleteMessage(int profileId, int id, int chatId) {
            base.Channel.DeleteMessage(profileId, id, chatId);
        }
        
        public System.Threading.Tasks.Task DeleteMessageAsync(int profileId, int id, int chatId) {
            return base.Channel.DeleteMessageAsync(profileId, id, chatId);
        }
    }
}
