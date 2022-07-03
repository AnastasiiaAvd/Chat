namespace TestChat.Models
{
    /// <summary>
    /// Модель предствления информации чата
    /// </summary>
    public class ChatInfoDto
    {
        /// <summary>
        /// Собеседник
        /// </summary>
        public string Companion { get; set; }

        /// <summary>
        /// Id чата
        /// </summary>
        public Guid ChatId { get; set; }
    }
}
