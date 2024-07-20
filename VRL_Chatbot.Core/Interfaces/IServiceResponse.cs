using VRL_Chatbot.Core.Common;

namespace VRL_Chatbot.Core.Interfaces
{
    public interface IServiceResponse<T>
    {
        T Data { get; set; }
        bool Status { get; set; }
        ServiceException Exception { get; set; }
    }
}
