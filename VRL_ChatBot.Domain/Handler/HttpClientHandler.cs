using VRL_ChatBot.Domain.Interfaces;

namespace VRL_ChatBot.Domain.Handler
{
    public class HttpClientHandler : IHttpHandler
    {
        private readonly HttpClient _httpClient;

        public HttpClientHandler()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            try
            {
                return await _httpClient.SendAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}