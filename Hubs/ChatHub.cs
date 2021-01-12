using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimuVladProiect.Models;
using TimuVladProiect.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace TimuVladProiect.Hubs
{
    [Authorize]
    public class ChatHub : Hub
 {
 public async Task SendMessage(string message)
 {
 await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
 }
 }
    }

