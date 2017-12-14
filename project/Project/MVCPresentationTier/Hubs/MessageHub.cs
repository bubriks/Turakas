using System;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.ServiceModel;
using MVCPresentationTier.MessageServiceReference;

namespace SignalRChat
{
    public class MessageHub : Hub, IMessageServiceCallback
    {
        public async Task JoinRoom(string chatId, string profileId, string clientId)//joins chat
        {
            await Groups.Add(Context.ConnectionId, chatId);
            MessageServiceClient client = new MessageServiceClient(new InstanceContext(this));
            client.JoinChat(Int32.Parse(chatId), Int32.Parse(profileId), clientId);
        }

        public void GetMessages(Message[] messages, string clientId)//gets all chats messages
        {
            foreach (Message message in messages)
            {
                Clients.Client(clientId).addChatMessage(message.Creator, message.Text);
            }
        }

        public void Send(string chatId, string profileId, string text)//send message method
        {
            MessageServiceClient client = new MessageServiceClient(new InstanceContext(this));
            client.CreateMessage(Int32.Parse(profileId), text, Int32.Parse(chatId));
        }

        public void AddMessage(Message message, string clientId)//callback if someone has written something
        {
            Clients.Client(clientId).addChatMessage(message.Creator, message.Text);
        }

        public void Show(bool result, string clientId)//show if succesfully connected
        {
            if (result)
            {
                Clients.Client(clientId).addChatMessage("Server", " You are connected!");
            }
            else
            {
                Clients.Client(clientId).addChatMessage("Server", " You couldn't connect!");
            }
        }

        #region For later
        public void GetChat(Chat chat, string clientId)
        {

        }

        public void RemoveMessage(int id, string clientId)
        {

        }

        public void Invite(bool result)
        {

        }

        public void WritingMessage(string clientId)
        {

        }

        public void GetOnlineProfiles(Profile[] profiles, string clientId)
        {

        }
        #endregion
    }
}