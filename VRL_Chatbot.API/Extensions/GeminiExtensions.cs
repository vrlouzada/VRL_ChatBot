using Microsoft.Extensions.Options;
using VRL_ChatBot.Domain.Config;
using VRL_ChatBot.Domain.Handler;
using VRL_ChatBot.Domain.Service;

namespace VRL_Chatbot.API.Extensions
{
    public static class GeminiExtensions
    {
        public static IServiceCollection AddGemini(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GeminiOptions>(configuration.GetSection("GeminiConfig"));

            services.AddTransient<GeminiDelegatingHandler>();

            services.AddHttpClient("GeminiService",
                (serviceProvider, httpClient) =>
                {
                    var geminiOptions = serviceProvider.GetRequiredService<IOptions<GeminiOptions>>().Value;
                    httpClient.BaseAddress = new Uri(geminiOptions.Url);
                })
                .AddHttpMessageHandler<GeminiDelegatingHandler>();

            return services;
        }
    }
}
