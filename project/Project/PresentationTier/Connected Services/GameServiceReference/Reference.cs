﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentationTier.GameServiceReference {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameServiceReference.IGameService", CallbackContract=typeof(PresentationTier.GameServiceReference.IGameServiceCallback))]
    public interface IGameService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/JoinGame")]
        void JoinGame(int gameId, int profileId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/JoinGame")]
        System.Threading.Tasks.Task JoinGameAsync(int gameId, int profileId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/LeaveGame")]
        void LeaveGame(int gameId, int profileId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/LeaveGame")]
        System.Threading.Tasks.Task LeaveGameAsync(int gameId, int profileId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/MakeChoice")]
        void MakeChoice(int gameId, int profileId, int choice);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/MakeChoice")]
        System.Threading.Tasks.Task MakeChoiceAsync(int gameId, int profileId, int choice);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/PlayerJoins")]
        void PlayerJoins(PresentationTier.GameServiceReference.Profile profile);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/PlayerLeaves")]
        void PlayerLeaves();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/Result")]
        void Result([System.ServiceModel.MessageParameterAttribute(Name="result")] int result1);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/Show")]
        void Show(bool result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameServiceChannel : PresentationTier.GameServiceReference.IGameService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameServiceClient : System.ServiceModel.DuplexClientBase<PresentationTier.GameServiceReference.IGameService>, PresentationTier.GameServiceReference.IGameService {
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void JoinGame(int gameId, int profileId) {
            base.Channel.JoinGame(gameId, profileId);
        }
        
        public System.Threading.Tasks.Task JoinGameAsync(int gameId, int profileId) {
            return base.Channel.JoinGameAsync(gameId, profileId);
        }
        
        public void LeaveGame(int gameId, int profileId) {
            base.Channel.LeaveGame(gameId, profileId);
        }
        
        public System.Threading.Tasks.Task LeaveGameAsync(int gameId, int profileId) {
            return base.Channel.LeaveGameAsync(gameId, profileId);
        }
        
        public void MakeChoice(int gameId, int profileId, int choice) {
            base.Channel.MakeChoice(gameId, profileId, choice);
        }
        
        public System.Threading.Tasks.Task MakeChoiceAsync(int gameId, int profileId, int choice) {
            return base.Channel.MakeChoiceAsync(gameId, profileId, choice);
        }
    }
}
