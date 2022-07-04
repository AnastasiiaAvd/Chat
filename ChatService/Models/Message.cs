using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatService.Data.Models
{
    /// <summary>
    /// Модель сообщения
    /// </summary>
    [Table ("Messages")]
    public class Message
    {
        public Message()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Id сообщения
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// /Id чата
        /// </summary>
        [ForeignKey("Chat")]
        [Required]
        [Index ("IX_ChatId", IsUnique=true)]
        public Guid ChatId { get; set; }

        /// <summary>
        /// Чат
        /// </summary>
        public virtual Chat Chat { get; set; }

        /// <summary>
        /// Id автора сообщения
        /// </summary>
        [ForeignKey("ApplicationUser")]
        [Required]
        [Index("IX_MessageAuthorId", IsUnique = true)]
        public Guid MessageAuthorId { get; set; }

        /// <summary>
        /// Автор сообщения
        /// </summary>
        //public virtual ApplicationUser MessageAuthor { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
}
