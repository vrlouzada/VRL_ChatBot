namespace VRL_ChatBot.Domain.Response
{
    public sealed class GeminiResponse
    {
        public Candidate[] Candidates { get; set; }
        public PromptFeedback PromptFeedback { get; set; }
    }
}