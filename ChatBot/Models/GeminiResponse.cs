using Newtonsoft.Json;

namespace ChatBot.Models
{
    public class GeminiResponse
    {
        [JsonProperty("candidates")]
        public List<Candidate>? Candidates { get; set; }

        [JsonProperty("error")]
        public GeminiError? Error { get; set; }
    }

    public class Candidate
    {
        [JsonProperty("content")]
        public GeminiContent? Content { get; set; }

        [JsonProperty("finishReason")]
        public string? FinishReason { get; set; }
    }

    public class GeminiError
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }
    }
}
