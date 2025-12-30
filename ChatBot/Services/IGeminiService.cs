using ChatBot.Models;

namespace ChatBot.Services
{
    public interface IGeminiService
    {
        Task<string> SendMessageAsync(string message, List<ChatMessage> conversationHistory);
        void SetApiKey(string apiKey);
        void SetModel(string model);
        bool IsConfigured { get; }
    }
}
