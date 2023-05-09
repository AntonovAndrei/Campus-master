using Application.Interfaces;

namespace Infrastructure.Email;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string userEmail, string emailSubject, string msg)
    {
        throw new NotImplementedException();
    }
}