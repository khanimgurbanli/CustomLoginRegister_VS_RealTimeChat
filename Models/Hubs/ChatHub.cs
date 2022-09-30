using Microsoft.AspNetCore.SignalR;

namespace LoginRegister.Models.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user,string message)
        {
           // string a = HttpContext.Session.GetString("username"); niye burdan elcataniq yoxdu?

            await Clients.All.SendAsync("ReceiveMessage",user, message);
        }
    }
}
