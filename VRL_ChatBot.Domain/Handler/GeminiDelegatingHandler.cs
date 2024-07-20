using Microsoft.Extensions.Options;
using VRL_ChatBot.Domain.Config;

namespace VRL_ChatBot.Domain.Handler
{
    public sealed class GeminiDelegatingHandler(IOptions<GeminiOptions> geminiOptions) : DelegatingHandler
    {
        private readonly GeminiOptions _geminiOptions = geminiOptions.Value;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("x-goog-api-key", $"{_geminiOptions.ApiKey}");

            return base.SendAsync(request, cancellationToken);
        }
    }
}