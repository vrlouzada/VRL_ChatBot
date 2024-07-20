namespace VRL_ChatBot.Domain.Interfaces
{
    public interface IGeminiClientService
    {
        Task<string> GenerateContentAsync(string prompt, CancellationToken cancellationToken);
    }
}