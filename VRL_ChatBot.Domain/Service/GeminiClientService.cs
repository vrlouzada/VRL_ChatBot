using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
using VRL_Chatbot.Core.Common;
using VRL_Chatbot.Core.Interfaces;
using VRL_ChatBot.Domain.Factory;
using VRL_ChatBot.Domain.Interfaces;
using VRL_ChatBot.Domain.Request;
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

        public async Task<IServiceResponse<string>> GenerateContentAsync(ContextoRequest request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<string>() { Status = false};

            try
            {
                var requestBody = GeminiRequestFactory.CreateRequest(request);
                var content = new StringContent(JsonConvert.SerializeObject(requestBody, _serializerSettings), Encoding.UTF8, "application/json");

                var httpClient = _httpClientFactory.CreateClient("GeminiService");

                var httpResponse = await httpClient.PostAsync(httpClient.BaseAddress, content, cancellationToken);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    response.Exception.Add($"ocorreu um error. Status code: {httpResponse.StatusCode}");
                }

                var responseBody = await httpResponse.Content.ReadAsStringAsync();

                var geminiResponse = JsonConvert.DeserializeObject<GeminiResponse>(responseBody);

                response.Data = geminiResponse?.Candidates[0].Content.Parts[0].Text;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Exception.Add(ex.Message);
            }
            
            return response;
        }
    }
}
