using VRL_Chatbot.Core.Interfaces;
using VRL_ChatBot.Domain.Request;

namespace VRL_ChatBot.Domain.Interfaces
{
    public interface IGeminiClientService
    {
        Task<IServiceResponse<string>> GenerateContentAsync(ContextoRequest request, CancellationToken cancellationToken);
    }
}