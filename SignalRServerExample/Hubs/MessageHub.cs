using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MessageHub:Hub
    {
        public async Task SendMessageAsync(string message) {

            #region Caller
            //Sadece bildirim gönderen client ile iletişim kurmak için kullanılır.
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion
            #region All
            //Servera bağlı tüm clientler ile iletişim kurmak için kullanılır.
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion
            #region Other
            //Servera bildirim gönderen dışında bağlı olan tüm clientler ile iletişim kurmak için kullanılır.
            await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

           // await Clients.All.SendAsync("receiveMessage",message);
        }
        public override async Task OnConnectedAsync()
        {
           await Clients.Caller.SendAsync("getConnectionId",Context.ConnectionId);
        }
    }
}
