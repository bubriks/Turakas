﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFSelf_Host.GameProxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameProxy.IGameService", CallbackContract=typeof(WCFSelf_Host.GameProxy.IGameServiceCallback))]
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
        void PlayerJoins(int id, string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/PlayerLeaves")]
        void PlayerLeaves();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/Result")]
        void Result([System.ServiceModel.MessageParameterAttribute(Name="result")] int result1);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/Show")]
        void Show(bool result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameServiceChannel : WCFSelf_Host.GameProxy.IGameService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameServiceClient : System.ServiceModel.DuplexClientBase<WCFSelf_Host.GameProxy.IGameService>, WCFSelf_Host.GameProxy.IGameService {
        
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
