using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace ChatService.Data.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            OwnerChats = new List<Chat>();
            GuestChats = new List<Chat>();
        }

        public virtual ICollection<Chat> OwnerChats { get; set; }
        public virtual ICollection<Chat> GuestChats { get; set; }

        /// <summary>
        /// Сообщения
        /// </summary>
        public virtual ICollection<Message> Messages { get; set; }
    }
}
