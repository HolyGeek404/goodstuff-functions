namespace GoodStuff.Functions.Functions.EmailNotification.Services;

public class EmailNotificationService(IEmailService emailService) : IEmailNotificationService
{
    public void ProcessRequest()
    {
       emailService.SendVerificationEmail("wmatkowski404@proton.me", Guid.Empty);
    }
}