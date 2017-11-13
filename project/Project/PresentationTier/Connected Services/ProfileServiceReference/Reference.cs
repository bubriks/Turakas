﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentationTier.ProfileServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Profile", Namespace="http://schemas.datacontract.org/2004/07/DataTier")]
    [System.SerializableAttribute()]
    public partial class Profile : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NicknameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProfileIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StatusIDField;
        
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
        public int StatusID {
            get {
                return this.StatusIDField;
            }
            set {
                if ((this.StatusIDField.Equals(value) != true)) {
                    this.StatusIDField = value;
                    this.RaisePropertyChanged("StatusID");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProfileServiceReference.IProfileService")]
    public interface IProfileService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/CreateProfile", ReplyAction="http://tempuri.org/IProfileService/CreateProfileResponse")]
        bool CreateProfile(PresentationTier.ProfileServiceReference.Profile profile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/CreateProfile", ReplyAction="http://tempuri.org/IProfileService/CreateProfileResponse")]
        System.Threading.Tasks.Task<bool> CreateProfileAsync(PresentationTier.ProfileServiceReference.Profile profile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/ReadProfile", ReplyAction="http://tempuri.org/IProfileService/ReadProfileResponse")]
        PresentationTier.ProfileServiceReference.Profile ReadProfile(string what, int by);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/ReadProfile", ReplyAction="http://tempuri.org/IProfileService/ReadProfileResponse")]
        System.Threading.Tasks.Task<PresentationTier.ProfileServiceReference.Profile> ReadProfileAsync(string what, int by);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/UpdateProfile", ReplyAction="http://tempuri.org/IProfileService/UpdateProfileResponse")]
        bool UpdateProfile(int profileId, PresentationTier.ProfileServiceReference.Profile profile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/UpdateProfile", ReplyAction="http://tempuri.org/IProfileService/UpdateProfileResponse")]
        System.Threading.Tasks.Task<bool> UpdateProfileAsync(int profileId, PresentationTier.ProfileServiceReference.Profile profile);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProfileServiceChannel : PresentationTier.ProfileServiceReference.IProfileService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProfileServiceClient : System.ServiceModel.ClientBase<PresentationTier.ProfileServiceReference.IProfileService>, PresentationTier.ProfileServiceReference.IProfileService {
        
        public ProfileServiceClient() {
        }
        
        public ProfileServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProfileServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProfileServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProfileServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CreateProfile(PresentationTier.ProfileServiceReference.Profile profile) {
            return base.Channel.CreateProfile(profile);
        }
        
        public System.Threading.Tasks.Task<bool> CreateProfileAsync(PresentationTier.ProfileServiceReference.Profile profile) {
            return base.Channel.CreateProfileAsync(profile);
        }
        
        public PresentationTier.ProfileServiceReference.Profile ReadProfile(string what, int by) {
            return base.Channel.ReadProfile(what, by);
        }
        
        public System.Threading.Tasks.Task<PresentationTier.ProfileServiceReference.Profile> ReadProfileAsync(string what, int by) {
            return base.Channel.ReadProfileAsync(what, by);
        }
        
        public bool UpdateProfile(int profileId, PresentationTier.ProfileServiceReference.Profile profile) {
            return base.Channel.UpdateProfile(profileId, profile);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateProfileAsync(int profileId, PresentationTier.ProfileServiceReference.Profile profile) {
            return base.Channel.UpdateProfileAsync(profileId, profile);
        }
    }
}