using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using TestChat.Data;
using TestChat.Data.Models;

namespace TestChat.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatHub(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        public async Task JoinToChat(string chatRoomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId);
        }

        public async Task Send(string message, string chatRoomId)
        {
            var user = await _userManager.GetUserAsync(Context.User);

            var newMessage = new Message
            {
                ChatId = Guid.Parse(chatRoomId),
                Text = message,
                MessageAuthorId = user.Id
            };

            await _applicationDbContext.Messages.AddAsync(newMessage);

            await _applicationDbContext.SaveChangesAsync();
            await Clients.Group(chatRoomId).SendAsync("Receive", message, user.UserName, newMessage.CreationDate);
        }
    }
}
