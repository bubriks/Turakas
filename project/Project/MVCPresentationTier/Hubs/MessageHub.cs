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
            MessageServiceClient client = new MessageServiceClient(new InstanceContext(this));
            chat = Int32.Parse(chatId);
            profile = Int32.Parse(profileId);
            client.CreateMessage(profile, text, chat);
        }

        public void AddMessage(Message message)
        {//pass -of profile id
            Clients.Group(chat.ToString()).addChatMessage(message.Creator, message.Text);
        }

        public async Task JoinRoom(string chatId, string profileId)
        {//$.connection.hub.id       Clients.Client(chatId).addChatMessage(profileId, " joined.");
            await Groups.Add(Context.ConnectionId, chatId);
            Clients.Group(chat.ToString()).addChatMessage(profileId, " joined.");
            MessageServiceClient client = new MessageServiceClient(new InstanceContext(this));
            chat = Int32.Parse(chatId);
            profile = Int32.Parse(profileId);
            client.JoinChat(chat, profile);
        }

        public void GetMessages(Message[] messages)
        {
            foreach (Message message in messages)
            {
                Clients.Group(chat.ToString()).addChatMessage(message.Creator, message.Text);
            }
        }

        public void Show(bool result)
        {
            if (result)
            {
                Clients.Group(chat.ToString()).addChatMessage(profile.ToString(), " Connected");
            }
            else
            {
                Clients.Group(chat.ToString()).addChatMessage(profile.ToString(), " Couldn't connect!");
            }
        }

        #region For later  
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