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
        var options = new RestClientOptions(new Uri(Constants.Configurations.Keys.EmailBaseUrl))
        {
            Authenticator = new HttpBasicAuthenticator("api", _appSettings.ApiKey)
        };

        _client = new RestClient(options);
        _request = new RestRequest();

        _request.AddParameter("domain", _appSettings.DomainName, ParameterType.UrlSegment);
        _request.Resource = "{domain}/messages";
        _request.AddParameter("from", Constants.Configurations.Keys.FromEmail);
        _client.BuildUri(_request);
    }

    public async Task Send(string toEmail, string subject, string msg)
    {
        ConfigMailServices();
        await SendMessage(toEmail, subject, msg);
    }

    public async Task SendEmailConfirm(string toEmail, string confirmLink)
    {
        ConfigMailServices();
        await SendMailConfirm(toEmail, confirmLink);
    }

    private async Task<bool> SendMessage(string toEmail, string subject, string msg)
    {
        _request.AddParameter("to", toEmail);
        _request.AddParameter("subject", subject);
        _request.AddParameter("text", msg);
        _request.Method = Method.Post;

        RestResponse result = await _client.ExecuteAsync(_request);
        return result.ResponseStatus.CompareTo(ResponseStatus.Completed) == 0 && result.IsSuccessful;
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
