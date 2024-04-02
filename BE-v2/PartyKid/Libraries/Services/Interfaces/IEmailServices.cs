namespace PartyKid;

public interface IEmailServices
{
    Task Send(string toEmail, string subject, string msg);

    Task SendEmailConfirm(string toEmail, string confirmLink);
}
