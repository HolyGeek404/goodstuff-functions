using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace GoodStuff.Functions.Functions.EmailNotification.Services;

public class EmailService(IConfiguration _config) : IEmailService
{
    public void SendVerificationEmail(string userEmail, Guid key)
    {
        var fromAddress = "progamingpartswebsite@gmail.com";
        var fromPassword = _config["AzureAd:EmailKey"];

        var smtpClient = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential(fromAddress, fromPassword)
        };

        using var message = new MailMessage(fromAddress, "wiktorzme@gmail.com"); // for easier testing
        message.Subject = "GoodStuff - Weryfikacja konta.";
        message.Body = "Witaj, w celu aktywacji swojego konta, wejdz w ten link: " +
                       $"https://localhost:5001/AccountVerification/?userEmail={userEmail}&key={key}";
        smtpClient.Send(message);
    }
}