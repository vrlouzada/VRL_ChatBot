namespace VRL_Chatbot.Core.Common
{
    public class ServiceException
    {
        public string Message { get; private set; }

        public void Add(string exceptionMessage)
        {
            this.Message = exceptionMessage;
        }
    }
}
