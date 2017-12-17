﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFSelf_Host.ChatProxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Activity", Namespace="http://schemas.datacontract.org/2004/07/DataTier")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WCFSelf_Host.ChatProxy.Group))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WCFSelf_Host.ChatProxy.Chat))]
    public partial class Activity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ActivityIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProfileIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeStampField;
        
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
        public int ActivityId {
            get {
                return this.ActivityIdField;
            }
            set {
                if ((this.ActivityIdField.Equals(value) != true)) {
                    this.ActivityIdField = value;
                    this.RaisePropertyChanged("ActivityId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProfileId {
            get {
                return this.ProfileIdField;
            }
            set {
                if ((this.ProfileIdField.Equals(value) != true)) {
                    this.ProfileIdField = value;
                    this.RaisePropertyChanged("ProfileId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TimeStamp {
            get {
                return this.TimeStampField;
            }
            set {
                if ((this.TimeStampField.Equals(value) != true)) {
                    this.TimeStampField = value;
                    this.RaisePropertyChanged("TimeStamp");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Group", Namespace="http://schemas.datacontract.org/2004/07/DataTier")]
    [System.SerializableAttribute()]
    public partial class Group : WCFSelf_Host.ChatProxy.Activity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Chat", Namespace="http://schemas.datacontract.org/2004/07/DataTier")]
    [System.SerializableAttribute()]
    public partial class Chat : WCFSelf_Host.ChatProxy.Activity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MaxNrOfUsersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Tuple<WCFSelf_Host.ChatProxy.Profile, object, string>[] UsersField;
        
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
        public System.Tuple<WCFSelf_Host.ChatProxy.Profile, object, string>[] Users {
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
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Profile", Namespace="http://schemas.datacontract.org/2004/07/DataTier")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Tuple<WCFSelf_Host.ChatProxy.Profile, object, string>[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Tuple<WCFSelf_Host.ChatProxy.Profile, object, string>))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WCFSelf_Host.ChatProxy.Chat))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WCFSelf_Host.ChatProxy.Activity))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WCFSelf_Host.ChatProxy.Chat[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WCFSelf_Host.ChatProxy.Group[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WCFSelf_Host.ChatProxy.Group))]
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChatProxy.IChatService", CallbackContract=typeof(WCFSelf_Host.ChatProxy.IChatServiceCallback))]
    public interface IChatService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Online")]
        void Online(int profileId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Online")]
        System.Threading.Tasks.Task OnlineAsync(int profileId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Offline")]
        void Offline(int profileId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Offline")]
        System.Threading.Tasks.Task OfflineAsync(int profileId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SaveChat")]
        void SaveChat(int profileId, WCFSelf_Host.ChatProxy.Chat chat);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SaveChat")]
        System.Threading.Tasks.Task SaveChatAsync(int profileId, WCFSelf_Host.ChatProxy.Chat chat);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/DeleteChat")]
        void DeleteChat(int profileId, int id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/DeleteChat")]
        System.Threading.Tasks.Task DeleteChatAsync(int profileId, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetChatsByName", ReplyAction="http://tempuri.org/IChatService/GetChatsByNameResponse")]
        WCFSelf_Host.ChatProxy.Chat[] GetChatsByName(string name, int profileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetChatsByName", ReplyAction="http://tempuri.org/IChatService/GetChatsByNameResponse")]
        System.Threading.Tasks.Task<WCFSelf_Host.ChatProxy.Chat[]> GetChatsByNameAsync(string name, int profileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetUsersGroups", ReplyAction="http://tempuri.org/IChatService/GetUsersGroupsResponse")]
        WCFSelf_Host.ChatProxy.Group[] GetUsersGroups(int profileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetUsersGroups", ReplyAction="http://tempuri.org/IChatService/GetUsersGroupsResponse")]
        System.Threading.Tasks.Task<WCFSelf_Host.ChatProxy.Group[]> GetUsersGroupsAsync(int profileId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/JoinChatWhithGroup")]
        void JoinChatWhithGroup(int groupId, int chatId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/JoinChatWhithGroup")]
        System.Threading.Tasks.Task JoinChatWhithGroupAsync(int groupId, int chatId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Notification")]
        void Notification(WCFSelf_Host.ChatProxy.Chat chat);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/JoinChat")]
        void JoinChat(int chatId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceChannel : WCFSelf_Host.ChatProxy.IChatService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatServiceClient : System.ServiceModel.DuplexClientBase<WCFSelf_Host.ChatProxy.IChatService>, WCFSelf_Host.ChatProxy.IChatService {
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Online(int profileId) {
            base.Channel.Online(profileId);
        }
        
        public System.Threading.Tasks.Task OnlineAsync(int profileId) {
            return base.Channel.OnlineAsync(profileId);
        }
        
        public void Offline(int profileId) {
            base.Channel.Offline(profileId);
        }
        
        public System.Threading.Tasks.Task OfflineAsync(int profileId) {
            return base.Channel.OfflineAsync(profileId);
        }
        
        public void SaveChat(int profileId, WCFSelf_Host.ChatProxy.Chat chat) {
            base.Channel.SaveChat(profileId, chat);
        }
        
        public System.Threading.Tasks.Task SaveChatAsync(int profileId, WCFSelf_Host.ChatProxy.Chat chat) {
            return base.Channel.SaveChatAsync(profileId, chat);
        }
        
        public void DeleteChat(int profileId, int id) {
            base.Channel.DeleteChat(profileId, id);
        }
        
        public System.Threading.Tasks.Task DeleteChatAsync(int profileId, int id) {
            return base.Channel.DeleteChatAsync(profileId, id);
        }
        
        public WCFSelf_Host.ChatProxy.Chat[] GetChatsByName(string name, int profileId) {
            return base.Channel.GetChatsByName(name, profileId);
        }
        
        public System.Threading.Tasks.Task<WCFSelf_Host.ChatProxy.Chat[]> GetChatsByNameAsync(string name, int profileId) {
            return base.Channel.GetChatsByNameAsync(name, profileId);
        }
        
        public WCFSelf_Host.ChatProxy.Group[] GetUsersGroups(int profileId) {
            return base.Channel.GetUsersGroups(profileId);
        }
        
        public System.Threading.Tasks.Task<WCFSelf_Host.ChatProxy.Group[]> GetUsersGroupsAsync(int profileId) {
            return base.Channel.GetUsersGroupsAsync(profileId);
        }
        
        public void JoinChatWhithGroup(int groupId, int chatId) {
            base.Channel.JoinChatWhithGroup(groupId, chatId);
        }
        
        public System.Threading.Tasks.Task JoinChatWhithGroupAsync(int groupId, int chatId) {
            return base.Channel.JoinChatWhithGroupAsync(groupId, chatId);
        }
    }
}
