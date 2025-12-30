using Newtonsoft.Json;

namespace ChatBot.Models
{
    public class GeminiRequest
    {
        [JsonProperty("contents")]
        public List<GeminiContent> Contents { get; set; } = new();

        [JsonProperty("generationConfig")]
        public GenerationConfig? GenerationConfig { get; set; }
    }

    public class GeminiContent
    {
        [JsonProperty("role")]
        public string Role { get; set; } = string.Empty;

        [JsonProperty("parts")]
        public List<GeminiPart> Parts { get; set; } = new();
    }

    public class GeminiPart
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;
    }

    public class GenerationConfig
    {
        [JsonProperty("maxOutputTokens")]
        public int MaxOutputTokens { get; set; } = 2048;

        [JsonProperty("temperature")]
        public double Temperature { get; set; } = 0.7;
    }
}
