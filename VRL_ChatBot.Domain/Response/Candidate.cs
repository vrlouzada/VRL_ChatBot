namespace VRL_ChatBot.Domain.Response
{
    public sealed class Candidate
    {
        public Content Content { get; set; }
        public string FinishReason { get; set; } = string.Empty;
        public int Index { get; set; }
        public SafetyRating[] SafetyRatings { get; set; }
    }

}
