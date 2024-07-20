using VRL_ChatBot.Domain.Interfaces;
using Domain = VRL_ChatBot.Domain.Handler;

namespace VRL_Chatbot.API.Extensions
{
    public static class HandlerExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services) 
        {
            services.AddScoped<IHttpHandler, Domain.HttpClientHandler>();
            return services;
        }
    }
}
