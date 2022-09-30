using Microsoft.AspNetCore.SignalR;

namespace LoginRegister.Models.Hubs
{
    public class ChatHub : Hub
    {
        IHttpContextAccessor _httpContextAccessor;

        public ChatHub(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SendMessage(string message)
        {
           string user = _httpContextAccessor.HttpContext.Session.GetString("username"); //niye burdan elcataniq yoxdu?

            await Clients.All.SendAsync("ReceiveMessage",user, message);
        }
    }
}
