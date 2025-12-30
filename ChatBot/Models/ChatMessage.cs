namespace ChatBot.Models
{
    public class ChatMessage
    {
        public string Role { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public ChatMessage() { }

        public ChatMessage(string role, string content)
        {
            Role = role;
            Content = content;
            Timestamp = DateTime.Now;
        }

        public bool IsUser => Role.Equals("user", StringComparison.OrdinalIgnoreCase);
        public bool IsAssistant => Role.Equals("model", StringComparison.OrdinalIgnoreCase);
    }
}
