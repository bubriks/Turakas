using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.ServiceModel;

namespace SignalRChat
{
    public class MessageHub : Hub
    {
        public void Send(string groupName, string name, string message)
        {
            // Call the addNewMessageToPage method to update clients in group.
            Clients.Group(groupName).addChatMessage(name, message);
        }

        public async Task JoinRoom(string roomName, string name)
        {
            await Groups.Add(Context.ConnectionId, roomName);
            Clients.Group(roomName).addChatMessage(name, " joined.");
        }
    }
}