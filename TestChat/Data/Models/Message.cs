namespace TestChat.Data.Models
{
    /// <summary>
    /// Модель сообщения
    /// </summary>
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
        public Guid Id { get; set; }

        /// <summary>
        /// /Id чата
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Чат
        /// </summary>
        public virtual Chat Chat { get; set; }

        /// <summary>
        /// Id автора сообщения
        /// </summary>
        public Guid MessageAuthorId { get; set; }

        /// <summary>
        /// Автор сообщения
        /// </summary>
        public virtual ApplicationUser MessageAuthor { get; set; }

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
