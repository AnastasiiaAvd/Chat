using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestChat.Data;
using TestChat.Data.Models;
using TestChat.Models;

namespace TestChat.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetChat(Guid chatId)
        {
            var messages = await (from message in _applicationDbContext.Messages
                    join user in _applicationDbContext.Users on message.MessageAuthorId equals user.Id
                    where message.ChatId == chatId
                    select new MessageDto
                        { DisplayName = user.UserName, Text = message.Text, CreationDate = message.CreationDate })
                .OrderBy(message => message.CreationDate).ToListAsync();


            return View(new ChatDto
            {
                ChatId = chatId,
                Messages = messages
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            var user = await GetCurrentUserAsync();

            var chats = await (from chat in _applicationDbContext.Chats
                join chatOwner in _applicationDbContext.Users on chat.ChatOwnerId equals chatOwner.Id
                join chatGuest in _applicationDbContext.Users on chat.ChatGuestId equals chatGuest.Id
                where chat.ChatGuestId == user.Id || chat.ChatOwnerId == user.Id
                select new ChatInfoDto
                {
                    ChatId = chat.Id,
                    Companion = chat.ChatGuestId == user.Id ? chatOwner.UserName : chatGuest.UserName
                }).ToListAsync();

            return View(new ChatsInfoDto
            {
                Chats = chats
            });
        }

        [HttpGet]
        public async Task<IActionResult> TryCreateChat(string companion)
        {
            var user = await _applicationDbContext.Users.AsQueryable()
                .FirstOrDefaultAsync(user => user.UserName == companion);

            if (user is null)
                return Json(new { success = false, message = "Не удалось найти такого пользователя" });

            var currentUser = await GetCurrentUserAsync();

            var currentChat = await _applicationDbContext.Chats.FirstOrDefaultAsync(chat =>
                chat.ChatGuestId == user.Id && chat.ChatOwnerId == currentUser.Id ||
                chat.ChatOwnerId == user.Id && chat.ChatGuestId == currentUser.Id);

            if (currentChat is not null)
                return Json(new { success = false, message = "Такой чат уже существует" });

            currentChat = new Chat
            {
                ChatGuestId = user.Id,
                ChatOwnerId = currentUser.Id
            };

            await _applicationDbContext.Chats.AddAsync(currentChat);
            await _applicationDbContext.SaveChangesAsync().ConfigureAwait(false);

            var chatInfo = new ChatInfoDto
            {
                ChatId = currentChat.Id,
                Companion = user.UserName
            };

            return Json(new { success = true, data = chatInfo });
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}