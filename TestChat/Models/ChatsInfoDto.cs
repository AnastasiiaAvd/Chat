namespace TestChat.Models
{
    /// <summary>
    /// Модель предствления чатов
    /// </summary>
    public class ChatsInfoDto
    {
        public ChatsInfoDto()
        {
            Chats = new List<ChatInfoDto>();
        }

        /// <summary>
        /// Чаты
        /// </summary>
        public List<ChatInfoDto> Chats { get; set; }
    }
}
