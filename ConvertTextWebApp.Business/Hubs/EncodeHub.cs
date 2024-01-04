using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ConvertTextWebApp.Business.Hubs
{
    public class EncodeHub : Hub
    {
        public async Task SendToClient(string character)
        {
            await Clients.All.SendAsync("ReceiveMessage", character);
        }
    }
}
