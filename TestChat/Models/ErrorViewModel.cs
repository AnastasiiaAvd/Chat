namespace TestChat.Models
{
    /// <summary>
    /// Модель предствления оштбки
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Id запроса
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Отобразить Id запроса
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}