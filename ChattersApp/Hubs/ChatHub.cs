using ChattersApp.User;
using Microsoft.AspNetCore.SignalR;

namespace ChattersApp.Hubs
{
    public class ChatHub:Hub
    {
        private readonly string _botUser;
        private readonly IDictionary<string, UserConnection> _connections;
        public ChatHub(IDictionary<string, UserConnection> connections)
        {

            _botUser = "Chatter Bot";
            _connections = connections;
        }


        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (_connections.TryGetValue(Context.ConnectionId,out UserConnection userConnection)) 
            { 
                _connections.Remove(Context.ConnectionId);
                Clients.Group(userConnection.RoomName).SendAsync("ReceiveMessage", _botUser, $"{userConnection.Nickname} has left");
            
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async  Task SendMessage(string message)
        {
            if (_connections.TryGetValue(Context.ConnectionId,out UserConnection userConnection))
            {
                await Clients.Groups(userConnection.RoomName)
                    .SendAsync("ReceiveMessage",userConnection.Nickname,message);
            }
        }
        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.RoomName);
            _connections[Context.ConnectionId] = userConnection;
            await Clients.Group(userConnection.RoomName).SendAsync("ReceiveMessage", _botUser, $"{userConnection.Nickname} has joined {userConnection.RoomName}");
        }
    }
}
