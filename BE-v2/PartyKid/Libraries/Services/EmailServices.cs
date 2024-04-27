using System.Net;
using System.Net.Mail;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;

namespace PartyKid;

public class EmailServices : IEmailServices
{
    private readonly AppSettings _appSettings;
    private RestClient _client;
    private RestRequest _request;

    public EmailServices(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    private void ConfigMailServices()
    {
        //     var options = new RestClientOptions(new Uri(Constants.Configurations.Keys.EmailBaseUrl))
        //     {
        //         Authenticator = new HttpBasicAuthenticator("api", _appSettings.ApiKey)
        //     };

        _client = new RestClient(Constants.Configurations.Keys.EmailBaseUrl);
        _request = new RestRequest();

        _request.AddHeader("Authorization", "Bearer " + _appSettings.ApiKey);
        _request.AddHeader("Content-Type", "application/json");
        _client.BuildUri(_request);
    }

    public async Task Send(string toEmail, string subject, string msg)
    {
        //ConfigMailServices();
        await SendMessage(toEmail, subject, msg);
    }

    public async Task SendEmailConfirm(string toEmail, string confirmLink)
    {
        ConfigMailServices();
        await SendMailConfirm(toEmail, confirmLink);
    }

    private async Task<bool> SendMessage(string toEmail, string subject, string msg)
    {
        try
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("bookingparty.system@gmail.com", "jbvs eljx aayn mste");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            MailAddress from = new MailAddress("bookingparty.system@gmail.com", "Booking Party System");
            MailAddress to = new MailAddress(toEmail);

            MailMessage mailBody = new MailMessage(from, to);
            mailBody.Body = msg;
            mailBody.Subject = subject;
            smtpClient.Send(mailBody);

            // var client = new SmtpClient("mail49.vietnix.vn", 465)
            // {
            //     Credentials = new NetworkCredential("bookingp", "hVt2*fDYx25)0Z"),
            //     EnableSsl = true
            // };

            // // var to = new { email = toEmail };
            // // var from = new { email = "test@gmail.com", name = "Party Booking System" };
            // // var bodyMail = new
            // // {
            // //     from = from,
            // //     to = new[] { to },
            // //     subject = subject,
            // //     text = msg
            // // };
            // // _request.AddParameter("application/json", JsonSerializer.Serialize(bodyMail), ParameterType.RequestBody);
            // // // _request.Method = Method.Post;

            // // var result = await _client.PostAsync(_request);
            // client.Send("bookingsystem@booking-party.com", toEmail, subject, msg);
            // var test = "";
            // return result.ResponseStatus.CompareTo(ResponseStatus.Completed) == 0 && result.IsSuccessful;
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    private async Task<bool> SendMailConfirm(string toEmail, string confirmLink)
    {
        string param = "{\"confirmLink\": \"" + confirmLink + "\"}";
        _request.AddParameter("to", toEmail);
        _request.AddParameter("subject", "Confirm your account");
        _request.AddParameter("template", "emailconfirms");
        _request.AddParameter("h:X-Mailgun-Variables", param);
        _request.Method = Method.Post;

        RestResponse result = await _client.ExecuteAsync(_request);
        return result.ResponseStatus.CompareTo(ResponseStatus.Completed) == 0 && result.IsSuccessful;
    }
}
