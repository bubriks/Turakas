﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentationTier.YoutubeService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="YoutubeService.IYoutubeService")]
    public interface IYoutubeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IYoutubeService/AddSong", ReplyAction="http://tempuri.org/IYoutubeService/AddSongResponse")]
        void AddSong(int activityID,string name, int duration, string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IYoutubeService/AddSong", ReplyAction="http://tempuri.org/IYoutubeService/AddSongResponse")]
        System.Threading.Tasks.Task AddSongAsync(int activityID, int artistID, int genreID, string name, int duration, string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IYoutubeService/GetVideoInfo", ReplyAction="http://tempuri.org/IYoutubeService/GetVideoInfoResponse")]
        string GetVideoInfo(string videoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IYoutubeService/GetVideoInfo", ReplyAction="http://tempuri.org/IYoutubeService/GetVideoInfoResponse")]
        System.Threading.Tasks.Task<string> GetVideoInfoAsync(string videoId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IYoutubeServiceChannel : PresentationTier.YoutubeService.IYoutubeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class YoutubeServiceClient : System.ServiceModel.ClientBase<PresentationTier.YoutubeService.IYoutubeService>, PresentationTier.YoutubeService.IYoutubeService {
        
        public YoutubeServiceClient() {
        }
        
        public YoutubeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public YoutubeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public YoutubeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public YoutubeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddSong(int activityID, string name, int duration, string url) {
            base.Channel.AddSong(activityID, name, duration, url);
        }
        
        public System.Threading.Tasks.Task AddSongAsync(int activityID, int artistID, int genreID, string name, int duration, string url) {
            return base.Channel.AddSongAsync(activityID, artistID, genreID, name, duration, url);
        }
        
        public string GetVideoInfo(string videoId) {
            return base.Channel.GetVideoInfo(videoId);
        }
        
        public System.Threading.Tasks.Task<string> GetVideoInfoAsync(string videoId) {
            return base.Channel.GetVideoInfoAsync(videoId);
        }
    }
}
