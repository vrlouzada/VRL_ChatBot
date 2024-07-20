using Microsoft.AspNetCore.Mvc;
using VRL_ChatBot.Domain.Interfaces;

namespace VRL_Chatbot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatBotController : ControllerBase
    {
        private readonly IGeminiClientService _geminiClientService;

        public ChatBotController(IGeminiClientService geminiClientService)
        {
            _geminiClientService = geminiClientService;
        }

        [HttpGet(Name = "SendMessage")]
        public  async Task<IActionResult> SendMessage(string message, CancellationToken cancellationToken) 
        {
            string response = string.Empty;
            try
            {
                response = await _geminiClientService.GenerateContentAsync(message, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }

            return Response(response, );
        }
    }
}
