using GoodStuff.Functions.Functions.EmailNotification.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace GoodStuff.Functions.Functions.EmailNotification;

public class EmailNotificationFunction(IEmailNotificationService service)
{
    [Function("EmailNotification")]

    public bool Run([HttpTrigger(AuthorizationLevel.Anonymous,
            "GET", Route = "notification")] HttpRequestData req)
    {
        service.ProcessRequest();
        return true;
    }
    
    
}