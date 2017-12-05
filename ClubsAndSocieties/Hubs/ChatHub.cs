using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;

namespace ClubsAndSocieties.Hubs
{
    [HubName("Chat")]    
    public class ChatHub: Hub
    {
        public void Join()
        {
            Clients.All.join($"{Context.ConnectionId} has joined the room");
        }

        //public Task Send(string data)
        //{
        //    return Clients.All.InvokeAsync("Send", data);
        //}
    }
}
