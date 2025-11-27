namespace GoodStuff.Functions.Functions.EmailNotification.Services;

public interface IEmailService
{
    void SendVerificationEmail(string userEmail, Guid key);
}