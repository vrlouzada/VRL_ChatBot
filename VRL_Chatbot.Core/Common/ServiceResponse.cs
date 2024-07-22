using VRL_Chatbot.Core.Interfaces;

namespace VRL_Chatbot.Core.Common
{
    public class ServiceResponse<T> : IServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Status { get; set; }
        public ServiceException Exception { get; set; }

        public ServiceResponse()
        {
            Exception = new ServiceException();
        }
    }
}
