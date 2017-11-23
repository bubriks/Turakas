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
        bool AddSong(string name, int duration, string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IYoutubeService/AddSong", ReplyAction="http://tempuri.org/IYoutubeService/AddSongResponse")]
        System.Threading.Tasks.Task<bool> AddSongAsync(string name, int duration, string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IYoutubeService/GetVideoTitle", ReplyAction="http://tempuri.org/IYoutubeService/GetVideoTitleResponse")]
        string GetVideoTitle(string videoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IYoutubeService/GetVideoTitle", ReplyAction="http://tempuri.org/IYoutubeService/GetVideoTitleResponse")]
        System.Threading.Tasks.Task<string> GetVideoTitleAsync(string videoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IYoutubeService/GetVideoDuration", ReplyAction="http://tempuri.org/IYoutubeService/GetVideoDurationResponse")]
        int GetVideoDuration(string videoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IYoutubeService/GetVideoDuration", ReplyAction="http://tempuri.org/IYoutubeService/GetVideoDurationResponse")]
        System.Threading.Tasks.Task<int> GetVideoDurationAsync(string videoId);
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
        
        public bool AddSong(string name, int duration, string url) {
            return base.Channel.AddSong(name, duration, url);
        }
        
        public System.Threading.Tasks.Task<bool> AddSongAsync(string name, int duration, string url) {
            return base.Channel.AddSongAsync(name, duration, url);
        }
        
        public string GetVideoTitle(string videoId) {
            return base.Channel.GetVideoTitle(videoId);
        }
        
        public System.Threading.Tasks.Task<string> GetVideoTitleAsync(string videoId) {
            return base.Channel.GetVideoTitleAsync(videoId);
        }
        
        public int GetVideoDuration(string videoId) {
            return base.Channel.GetVideoDuration(videoId);
        }
        
        public System.Threading.Tasks.Task<int> GetVideoDurationAsync(string videoId) {
            return base.Channel.GetVideoDurationAsync(videoId);
        }
    }
}
