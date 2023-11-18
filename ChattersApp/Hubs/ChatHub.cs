using ChattersApp.User;
using Microsoft.AspNetCore.SignalR;

namespace ChattersApp.Hubs
{
    public class ChatHub:Hub
    {
        private readonly string _botUser;
        public ChatHub()
        {
            _botUser = "Chatter Bot";
        }

        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.RoomName);
            await Clients.Group(userConnection.RoomName).SendAsync("ReceiveMessage", _botUser, $"{userConnection.Nickname} has joined {userConnection.RoomName}");
        }
    }
}
