using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatService.Data.Models
{
    /// <summary>
    /// Модель чата
    /// </summary>
    [Table ("Chats")]
    public sealed class Chat
    {
        public Chat()
        {
            Id = Guid.NewGuid();
            Messages = new List<Message>();
        }

        /// <summary>
        /// Id чата
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Id владельца чата
        /// </summary>
        [Required]
        [ForeignKey("ApplicationUser")]
        [Index("IX_ChatOwnerId", IsUnique = true)]
        public Guid ChatOwnerId { get; set; }

        /// <summary>
        /// Владелец чата
        /// </summary>
        //public ApplicationUser ChatOwner { get; set; }

        /// <summary>
        /// Id гостя
        /// </summary>
        [ForeignKey("ApplicationUser")]
        [Required]
        [Index("IX_ChatGuestId", IsUnique = true)]
        public Guid ChatGuestId { get; set; }

        /// <summary>
        /// Гость
        /// </summary>
        //public ApplicationUser ChatGuest { get; set; }

        /// <summary>
        /// Сообщения чата
        /// </summary>
        public ICollection<Message> Messages { get; set; }
    }
}
