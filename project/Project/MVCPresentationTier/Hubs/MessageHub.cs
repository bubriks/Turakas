using System;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.ServiceModel;
using MVCPresentationTier.MessageServiceReference;

namespace SignalRChat
{
    public class MessageHub : Hub, IMessageServiceCallback
    {
        private int chat;
        private int profile;
        public void Send(string chatId, string profileId, string text)
        {
            Clients.Group(chatId).addChatMessage(profileId, text);
        }

        public async Task JoinRoom(string chatId, string profileId)
        {
            await Groups.Add(Context.ConnectionId, chatId);
            Send(chatId, profileId, " joined.");
            MessageServiceClient client = new MessageServiceClient(new InstanceContext(this));
            chat = Int32.Parse(chatId);
            profile = Int32.Parse(profileId);
            client.JoinChat(chat, profile);
        }

        public void GetMessages(Message[] messages)
        {
            foreach (Message message in messages)
            {
                Send(chat.ToString(), profile.ToString(), message.Text + "- was sent!!!!!!!!!!!!!!!");
            }
            Send(chat.ToString(), profile.ToString(), "messages were sent!!!!!!!!!!!!!!!");
        }

        public void Show(bool result)
        {
            if (result)
            {
                Send(chat.ToString(), profile.ToString(), "succes");
            }
            else
            {
                Send(chat.ToString(), profile.ToString(), "fail");
            }
        }

        #region For later  
        public void AddMessage(Message message)
        {
            
        }

        public void GetChat(Chat chat)
        {

        }

        public void RemoveMessage(int id)
        {

        }

        public void Invite(bool result)
        {

        }

        public void WritingMessage()
        {

        }

        public void GetOnlineProfiles(Profile[] profiles)
        {

        }
        #endregion
    }
}