using VRL_ChatBot.Domain.Interfaces;
using VRL_ChatBot.Domain.Service;

namespace VRL_Chatbot.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGeminiClientService, GeminiClientService>();

            return services;
        }
    }
}