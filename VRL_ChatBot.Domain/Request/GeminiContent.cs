namespace VRL_ChatBot.Domain.Request
{
    public sealed class GeminiContent
    {
        public string Role { get; set; } = string.Empty;
        public GeminiPart[] Parts { get; set; }
    }
}
