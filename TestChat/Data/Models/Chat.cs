namespace TestChat.Data.Models
{
    /// <summary>
    /// Модель чата
    /// </summary>
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
        public Guid Id { get; set; }
        
        /// <summary>
        /// Id владельца чата
        /// </summary>
        public Guid ChatOwnerId { get; set; }

        /// <summary>
        /// Владелец чата
        /// </summary>
        public ApplicationUser ChatOwner { get; set; }

        /// <summary>
        /// Id гостя
        /// </summary>
        public Guid ChatGuestId { get; set; }

        /// <summary>
        /// Гость
        /// </summary>
        public ApplicationUser ChatGuest { get; set; }

        /// <summary>
        /// Сообщения чата
        /// </summary>
        public ICollection<Message> Messages { get; set; }
    }
}
