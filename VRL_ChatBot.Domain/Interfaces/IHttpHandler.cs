namespace VRL_ChatBot.Domain.Interfaces
{
    public interface IHttpHandler
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
