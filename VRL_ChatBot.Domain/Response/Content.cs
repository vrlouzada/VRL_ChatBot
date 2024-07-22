namespace VRL_ChatBot.Domain.Response
{
    public sealed class Content
    {
        public Part[] Parts { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
