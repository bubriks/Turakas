﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentationTier.GroupServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Group", Namespace="http://schemas.datacontract.org/2004/07/DataTier")]
    [System.SerializableAttribute()]
    public partial class Group : PresentationTier.GroupServiceReference.Activity {
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Activity", Namespace="http://schemas.datacontract.org/2004/07/DataTier")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PresentationTier.GroupServiceReference.Group))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Profile", Namespace="http://schemas.datacontract.org/2004/07/DataTier")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PresentationTier.GroupServiceReference.Group[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PresentationTier.GroupServiceReference.Group))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PresentationTier.GroupServiceReference.Activity))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PresentationTier.GroupServiceReference.Profile[]))]
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GroupServiceReference.IGroupService")]
    public interface IGroupService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/CreateGroup", ReplyAction="http://tempuri.org/IGroupService/CreateGroupResponse")]
        bool CreateGroup(string name, int profileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/CreateGroup", ReplyAction="http://tempuri.org/IGroupService/CreateGroupResponse")]
        System.Threading.Tasks.Task<bool> CreateGroupAsync(string name, int profileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/DeleteGroup", ReplyAction="http://tempuri.org/IGroupService/DeleteGroupResponse")]
        bool DeleteGroup(int profileId, int groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/DeleteGroup", ReplyAction="http://tempuri.org/IGroupService/DeleteGroupResponse")]
        System.Threading.Tasks.Task<bool> DeleteGroupAsync(int profileId, int groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/UpdateGroup", ReplyAction="http://tempuri.org/IGroupService/UpdateGroupResponse")]
        bool UpdateGroup(string name, int groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/UpdateGroup", ReplyAction="http://tempuri.org/IGroupService/UpdateGroupResponse")]
        System.Threading.Tasks.Task<bool> UpdateGroupAsync(string name, int groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/GetUsersGroups", ReplyAction="http://tempuri.org/IGroupService/GetUsersGroupsResponse")]
        PresentationTier.GroupServiceReference.Group[] GetUsersGroups(int profileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/GetUsersGroups", ReplyAction="http://tempuri.org/IGroupService/GetUsersGroupsResponse")]
        System.Threading.Tasks.Task<PresentationTier.GroupServiceReference.Group[]> GetUsersGroupsAsync(int profileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/AddMember", ReplyAction="http://tempuri.org/IGroupService/AddMemberResponse")]
        bool AddMember(string memberName, int groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/AddMember", ReplyAction="http://tempuri.org/IGroupService/AddMemberResponse")]
        System.Threading.Tasks.Task<bool> AddMemberAsync(string memberName, int groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/RemoveMember", ReplyAction="http://tempuri.org/IGroupService/RemoveMemberResponse")]
        bool RemoveMember(int profileId, int groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/RemoveMember", ReplyAction="http://tempuri.org/IGroupService/RemoveMemberResponse")]
        System.Threading.Tasks.Task<bool> RemoveMemberAsync(int profileId, int groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/GetUsers", ReplyAction="http://tempuri.org/IGroupService/GetUsersResponse")]
        PresentationTier.GroupServiceReference.Profile[] GetUsers(int groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/GetUsers", ReplyAction="http://tempuri.org/IGroupService/GetUsersResponse")]
        System.Threading.Tasks.Task<PresentationTier.GroupServiceReference.Profile[]> GetUsersAsync(int groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/GetOnlineMembers", ReplyAction="http://tempuri.org/IGroupService/GetOnlineMembersResponse")]
        PresentationTier.GroupServiceReference.Profile[] GetOnlineMembers(int groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupService/GetOnlineMembers", ReplyAction="http://tempuri.org/IGroupService/GetOnlineMembersResponse")]
        System.Threading.Tasks.Task<PresentationTier.GroupServiceReference.Profile[]> GetOnlineMembersAsync(int groupId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGroupServiceChannel : PresentationTier.GroupServiceReference.IGroupService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GroupServiceClient : System.ServiceModel.ClientBase<PresentationTier.GroupServiceReference.IGroupService>, PresentationTier.GroupServiceReference.IGroupService {
        
        public GroupServiceClient() {
        }
        
        public GroupServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GroupServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GroupServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GroupServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CreateGroup(string name, int profileId) {
            return base.Channel.CreateGroup(name, profileId);
        }
        
        public System.Threading.Tasks.Task<bool> CreateGroupAsync(string name, int profileId) {
            return base.Channel.CreateGroupAsync(name, profileId);
        }
        
        public bool DeleteGroup(int profileId, int groupId) {
            return base.Channel.DeleteGroup(profileId, groupId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteGroupAsync(int profileId, int groupId) {
            return base.Channel.DeleteGroupAsync(profileId, groupId);
        }
        
        public bool UpdateGroup(string name, int groupId) {
            return base.Channel.UpdateGroup(name, groupId);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateGroupAsync(string name, int groupId) {
            return base.Channel.UpdateGroupAsync(name, groupId);
        }
        
        public PresentationTier.GroupServiceReference.Group[] GetUsersGroups(int profileId) {
            return base.Channel.GetUsersGroups(profileId);
        }
        
        public System.Threading.Tasks.Task<PresentationTier.GroupServiceReference.Group[]> GetUsersGroupsAsync(int profileId) {
            return base.Channel.GetUsersGroupsAsync(profileId);
        }
        
        public bool AddMember(string memberName, int groupId) {
            return base.Channel.AddMember(memberName, groupId);
        }
        
        public System.Threading.Tasks.Task<bool> AddMemberAsync(string memberName, int groupId) {
            return base.Channel.AddMemberAsync(memberName, groupId);
        }
        
        public bool RemoveMember(int profileId, int groupId) {
            return base.Channel.RemoveMember(profileId, groupId);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveMemberAsync(int profileId, int groupId) {
            return base.Channel.RemoveMemberAsync(profileId, groupId);
        }
        
        public PresentationTier.GroupServiceReference.Profile[] GetUsers(int groupId) {
            return base.Channel.GetUsers(groupId);
        }
        
        public System.Threading.Tasks.Task<PresentationTier.GroupServiceReference.Profile[]> GetUsersAsync(int groupId) {
            return base.Channel.GetUsersAsync(groupId);
        }
        
        public PresentationTier.GroupServiceReference.Profile[] GetOnlineMembers(int groupId) {
            return base.Channel.GetOnlineMembers(groupId);
        }
        
        public System.Threading.Tasks.Task<PresentationTier.GroupServiceReference.Profile[]> GetOnlineMembersAsync(int groupId) {
            return base.Channel.GetOnlineMembersAsync(groupId);
        }
    }
}
