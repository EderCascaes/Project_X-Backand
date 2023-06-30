using Newtonsoft.Json;
using Project_X.Domain.Notifications;




namespace Project_X.Services.ExceptionService
{
    public class WebApiException : Exception
    {
        public WebApiException(string exceptionMessage, string content = null) : base(string.IsNullOrEmpty(content) ? exceptionMessage : exceptionMessage + " -> " + content)
        {
            Content = content;

            if (!string.IsNullOrEmpty(content))
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<ApiNotifications>(content);
                    MessageApi = obj.Message;

                }
                catch { MessageApi = content; }

            }

        }

        public string Content { get; private set; }

        public string MessageApi { get; private set; }
    }


}
