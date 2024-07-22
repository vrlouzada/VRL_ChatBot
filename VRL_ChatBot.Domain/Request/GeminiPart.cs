namespace VRL_ChatBot.Domain.Request
{
    public sealed class GeminiPart
    {
        // This one interests us the most
        public string Text { get; set; } = string.Empty;
    }
}