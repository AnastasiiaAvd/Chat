namespace TestChat.Models
{
    /// <summary>
    /// Модель предствления сообщения
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Имя автора сообщения
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }
    }
}
