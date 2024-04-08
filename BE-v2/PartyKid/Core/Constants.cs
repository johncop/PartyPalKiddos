﻿namespace PartyKid;

public static class Constants
{
    public static class Configurations
    {
        public static class Keys
        {
            public const string BasePath = "System:";
            public const string ServiceAssembliesPattern = "AllowedAssemblyPattern";
            public const string UserId = "36d92587-988b-4e5c-8d9c-0e8aef7a9f0e";

            public const string EmailBaseUrl = "https://api.mailgun.net/v3";
            public const string FromEmail = "Party Kid Booking System<phamhoangdung4@gmail.com>";

            public const string ConfirmEmailUrl = "";

            public static class FeatureToggles
            {
                public const string CORS = "AllowedOrigins";
                public const string BasePath = "Features:";
                public const string IsEnable = "Enabled";
            }
        }

        public static class Messages
        {
            public const string MissingCORSConfigurations = "CORS configurations for this API are missing.";
            public const string MissingServiceAssembliesPattern = "Service assemblies pattern cannot be null or empty.";
        }
    }

    public static class HTTPClient
    {
        public const string DefaultRoute = "";
        public const string ApiVersionHeader = "x-api-version";
        public const string BearerTokenHeader = "Bearer";
        public const string RequestAccessToken = "access_token";

        public static class Formatters
        {
            public const string RESTful = "application/json;";
            public const string ResponseContentType = "application/json; charset=utf-8";
            public const string RESTfullProblemDetails = "application/problem+json";
            public const string XML = "xml";
        }

        public static class Messages
        {
            public const string InvalidHttpMethod = "HTTP Method is invalid.";
            public const string InvalidHttpContent = "HTTP Content is invalid.";
            public const string InvalidBearerToken = "Bearer token cannot be null or empty.";
            public const string InvalidRequestURI = "Request URL cannot be null or empty.";
            public const string InvalidRequestTimeout = "Request timeout is invalid.";
            public const string InvalidRequestAcceptHeader = "Accept header cannot be null or empty.";
        }
    }

    public static class RequestHandling
    {
        public static class Messages
        {
            public const string ValidationExceptionTitle = "Request validation error";
            public const string ValidationExceptionDetail = "One or more validation errors occurred.";
            public const string DomainExceptionTitle = "Business logic error";
            public const string UnhandledExceptionTitle = "An unexpected error occurred";

            public const string Success = "Success.";
            public const string InvalidResponse = "Invalid response.";
            public const string InvalidRequest = "Invalid request. The request cannot be null.";
            public const string InvalidResponseMessage = "Invalid response message. Response message cannot be null or empty.";

            public const string SendEmailExceptionTitle = "Server couldn't send email to confirm this account, please try again!";
        }
    }

    public static class ApplicationSettings
    {
        public static class DefaultValues
        {
            public const string StringEmptyValue = "N/A";
            public const string ShortDateFormat = "dd/MM/yyyy";
            public const int PageSize = 25;
        }

        public const string ApiVersionGroupFormat = "'v'VV";
    }

    public static class Transactions
    {
        public static class Messages
        {
            public const string CommandExecutedWithoutAffectedRow = "Command has been executed successfully with 0 row(s) affected.";
            public const string TransactionCompletedWithoutAffectedRow = "Transaction has been completed with 0 row(s) affected.";
            public const string AddComplete = "Create success";
            public const string DeleteComplete = "Delete success";
            public const string NotFound = "Not found record. Please try againt";
        }
    }

    public static class EmbedReport
    {
        public static class Messages
        {
            public const string AuthenticationFailed = "Authentication Failed.";
            public const string ApplicationIdEmpty = "ApplicationId is empty. please register your application as Native app in https://dev.powerbi.com/apps and fill client Id in web.config.";
            public const string ReportNotFound = "No reports were found in the workspace.";
            public const string ReportIdNotFound = "No report with the given ID was found in the workspace. Make sure ReportId is valid.";
            public const string GenerateTokenFailed = "Failed to generate embed token.";
            public const string WorkspaceIdEmpty = "WorkspaceId is empty. Please select a group you own and fill its Id in web.config.";
            public const string ApplicationSecretEmpty = "ApplicationSecret is empty. please register your application as Web app and fill appSecret in web.config.";
            public const string TenantEmpty = "Invalid Tenant. Please fill Tenant ID in Tenant under web.config.";
            public const string PowerBiApiUrlEmpty = "PowerBi url is empty.";
            public const string AuthenticationUrlEmpty = "Authentication url is empty.";
        }
    }

    public static class AuthHandling
    {
        public static class Messages
        {
            public const string NotFoundUser = "Not found user";
            public const string UpdatePassword = "You have been request reset password. Please update your password and login again!";
            public const string IsValid = "Username/Email or password is incorrect. Please try again";
            public const string IsNotAllowed = "You need confirm your email and login again!";
            public const string UnAuthorized = "You need login to perform this operation.";
            public const string Forbidden = "You cannot access this feature.";
        }
    }

    public static class UserHandling
    {
        public static class Messages
        {
            public const string ChangePassworSuccess = "Password is changed. Please login again.";
            public const string ChangePasswordFailed = "Change password have something wrong. Please try again.";
            public const string ResetPasswordSuccess = "Password is reset. Please check mail to get new password";
            public const string ResetPasswordFailed = "Something wrong when reset your password. Please try again.";
            public const string UpdateUserFailure = "Can't Update User. Please check information again and try again.";
            public const string UpdateUserSucceed = "Update Succeed.";
            public const string ForgotPassword = "New password was sent your email. Please check and login again.";
            public const string EmailEmpty = "Please enter your email.";
        }
    }

    public static class BookingHandling
    {
        public static class Messages
        {
            public const string NotFoundBooking = "Booking Not Found. Please try again.";
            public const string IdEmpty = "Id of booking must have value. Please try again.";
        }
    }
}
