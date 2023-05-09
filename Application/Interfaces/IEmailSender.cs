namespace Application.Interfaces;

public interface IEmailSender
{
    public Task SendEmailAsync(string userEmail, string emailSubject, string msg);
}