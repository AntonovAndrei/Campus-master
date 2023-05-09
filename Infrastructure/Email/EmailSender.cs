using Application.Interfaces;

namespace Infrastructure.Email;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string userEmail, string emailSubject, string msg)
    {
        Console.WriteLine("Email not send because not implement");
        throw new NotImplementedException();
    }
}