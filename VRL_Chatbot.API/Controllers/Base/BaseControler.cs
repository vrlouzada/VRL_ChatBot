using Microsoft.AspNetCore.Mvc;
using VRL_Chatbot.Core.Common;
using VRL_Chatbot.Core.Enum;

namespace VRL_Chatbot.API.Controllers.Base
{
    public class BaseControler : ControllerBase
    {
        public IActionResult Response<T>(ServiceResponse<T> response, StatusCode statusCode)
        {

            switch (statusCode)
            {
                case Core.Enum.StatusCode.Success:
                    response.Exception = null;
                    return Ok(response);
                    default:
                return BadRequest(response);
            }
        }
    }
}
