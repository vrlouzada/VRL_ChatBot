using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;
using VRL_ChatBot.Domain.Config;
using VRL_ChatBot.Domain.Factory;
using VRL_ChatBot.Domain.Interfaces;
using VRL_ChatBot.Domain.Response;

namespace VRL_ChatBot.Domain.Service
{
    public sealed class GeminiClientService : IGeminiClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly JsonSerializerSettings _serializerSettings = new()
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public GeminiClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GenerateContentAsync(string prompt, CancellationToken cancellationToken)
        {
            var requestBody = GeminiRequestFactory.CreateRequest(prompt);
            var content = new StringContent(JsonConvert.SerializeObject(requestBody, _serializerSettings), Encoding.UTF8, "application/json");

            var httpClient = _httpClientFactory.CreateClient("GeminiService");
            
            var httpResponse = await httpClient.PostAsync(httpClient.BaseAddress, content, cancellationToken);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return $"ocorreu um error. Status code: {httpResponse.StatusCode}";
            }

            var responseBody = await httpResponse.Content.ReadAsStringAsync();

            var geminiResponse = JsonConvert.DeserializeObject<GeminiResponse>(responseBody);

            var geminiResponseText = geminiResponse?.Candidates[0].Content.Parts[0].Text;

            return geminiResponseText;
        }
    }
}
