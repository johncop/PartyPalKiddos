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
        // var client = new RestClient("https://send.api.mailtrap.io/api/send");
        // var request = new RestRequest(Method.POST);
        // request.AddHeader("Content-Type", "application/json");
        // request.AddHeader("Accept", "application/json");
        // request.AddHeader("Api-Token", "123");
        // request.AddParameter("application/json", "{\n  \"to\": [\n    {\n      \"email\": \"john_doe@example.com\",\n      \"name\": \"John Doe\"\n    }\n  ],\n  \"cc\": [\n    {\n      \"email\": \"jane_doe@example.com\",\n      \"name\": \"Jane Doe\"\n    }\n  ],\n  \"bcc\": [\n    {\n      \"email\": \"james_doe@example.com\",\n      \"name\": \"Jim Doe\"\n    }\n  ],\n  \"from\": {\n    \"email\": \"sales@example.com\",\n    \"name\": \"Example Sales Team\"\n  },\n  \"attachments\": [\n    {\n      \"content\": \"PCFET0NUWVBFIGh0bWw+CjxodG1sIGxhbmc9ImVuIj4KCiAgICA8aGVhZD4KICAgICAgICA8bWV0YSBjaGFyc2V0PSJVVEYtOCI+CiAgICAgICAgPG1ldGEgaHR0cC1lcXVpdj0iWC1VQS1Db21wYXRpYmxlIiBjb250ZW50PSJJRT1lZGdlIj4KICAgICAgICA8bWV0YSBuYW1lPSJ2aWV3cG9ydCIgY29udGVudD0id2lkdGg9ZGV2aWNlLXdpZHRoLCBpbml0aWFsLXNjYWxlPTEuMCI+CiAgICAgICAgPHRpdGxlPkRvY3VtZW50PC90aXRsZT4KICAgIDwvaGVhZD4KCiAgICA8Ym9keT4KCiAgICA8L2JvZHk+Cgo8L2h0bWw+Cg==\",\n      \"filename\": \"index.html\",\n      \"type\": \"text/html\",\n      \"disposition\": \"attachment\"\n    }\n  ],\n  \"custom_variables\": {\n    \"user_id\": \"45982\",\n    \"batch_id\": \"PSJ-12\"\n  },\n  \"headers\": {\n    \"X-Message-Source\": \"dev.mydomain.com\"\n  },\n  \"subject\": \"Your Example Order Confirmation\",\n  \"text\": \"Congratulations on your order no. 1234\",\n  \"category\": \"API Test\"\n}", ParameterType.RequestBody);
        // IRestResponse response = client.Execute(request);

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
