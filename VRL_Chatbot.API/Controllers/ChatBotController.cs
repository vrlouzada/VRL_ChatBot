using Microsoft.AspNetCore.Mvc;
using VRL_Chatbot.API.Controllers.Base;
using VRL_Chatbot.Core.Common;
using VRL_ChatBot.Domain.Interfaces;
using VRL_ChatBot.Domain.Request;

namespace VRL_Chatbot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatBotController : BaseControler
    {
        private readonly IGeminiClientService _geminiClientService;

        public ChatBotController(IGeminiClientService geminiClientService)
        {
            _geminiClientService = geminiClientService;
        }

        [HttpGet(Name = "SendMessage")]
        public  async Task<IActionResult> SendMessage([FromBody] PromptRequest request, CancellationToken cancellationToken) 
        {
            var response = new ServiceResponse<string>() { Status = false };

            try
            {
                var result = await _geminiClientService.GenerateContentAsync(request, cancellationToken);

                if(result is null)
                {
                    response.Exception.Add("Ocorreu algum problema técnico");
                    return BadRequest(response);
                }

                response.Data = result.Data;
                response.Status = result.Status;
                response.Exception = result.Exception;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Exception.Add(ex.Message);
                return Response(response, Core.Enum.StatusCode.BadRequest);
            }

            return Response(response, Core.Enum.StatusCode.Success);
        }
    }
}
