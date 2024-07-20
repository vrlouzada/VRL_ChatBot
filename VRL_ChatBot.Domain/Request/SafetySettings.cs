namespace VRL_ChatBot.Domain.Request
{
    public sealed class SafetySettings
    {
        public string Category { get; set; } = string.Empty;
        public string Threshold { get; set; } = string.Empty;
    }
}