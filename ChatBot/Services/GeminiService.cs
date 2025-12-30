using System.Text;
using ChatBot.Models;
using Newtonsoft.Json;

namespace ChatBot.Services
{
    public class GeminiService : IGeminiService
    {
        private readonly HttpClient _httpClient;
        private string _apiKey = string.Empty;
        private string _model = "gemini-1.5-flash";
        private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models";

        public bool IsConfigured => !string.IsNullOrWhiteSpace(_apiKey);

        public GeminiService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
        }

        public void SetApiKey(string apiKey)
        {
            _apiKey = apiKey?.Trim() ?? string.Empty;
        }

        public void SetModel(string model)
        {
            if (!string.IsNullOrWhiteSpace(model))
            {
                _model = model;
            }
        }

        public async Task<string> SendMessageAsync(string message, List<ChatMessage> conversationHistory)
        {
            if (!IsConfigured)
            {
                return "❌ Hata: API anahtarı ayarlanmamış. Lütfen Ayarlar'dan Gemini API anahtarınızı girin.";
            }

            try
            {
                var request = BuildRequest(message, conversationHistory);
                var jsonContent = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var url = $"{BaseUrl}/{_model}:generateContent?key={_apiKey}";
                var response = await _httpClient.PostAsync(url, httpContent);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonConvert.DeserializeObject<GeminiResponse>(responseContent);
                    return $"❌ API Hatası: {errorResponse?.Error?.Message ?? response.StatusCode.ToString()}";
                }

                var geminiResponse = JsonConvert.DeserializeObject<GeminiResponse>(responseContent);
                
                if (geminiResponse?.Candidates?.FirstOrDefault()?.Content?.Parts?.FirstOrDefault()?.Text is string text)
                {
                    return text;
                }

                return "❌ Yanıt alınamadı. Lütfen tekrar deneyin.";
            }
            catch (TaskCanceledException)
            {
                return "❌ İstek zaman aşımına uğradı. Lütfen tekrar deneyin.";
            }
            catch (HttpRequestException ex)
            {
                return $"❌ Bağlantı hatası: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"❌ Beklenmeyen hata: {ex.Message}";
            }
        }

        private GeminiRequest BuildRequest(string message, List<ChatMessage> conversationHistory)
        {
            var request = new GeminiRequest
            {
                Contents = new List<GeminiContent>(),
                GenerationConfig = new GenerationConfig
                {
                    MaxOutputTokens = 2048,
                    Temperature = 0.7
                }
            };

            // Sohbet geçmişini ekle
            foreach (var msg in conversationHistory)
            {
                request.Contents.Add(new GeminiContent
                {
                    Role = msg.Role,
                    Parts = new List<GeminiPart> { new GeminiPart { Text = msg.Content } }
                });
            }

            // Yeni mesajı ekle
            request.Contents.Add(new GeminiContent
            {
                Role = "user",
                Parts = new List<GeminiPart> { new GeminiPart { Text = message } }
            });

            return request;
        }
    }
}
