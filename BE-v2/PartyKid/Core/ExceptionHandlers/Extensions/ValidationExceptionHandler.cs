

using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

public sealed class ValidationExceptionHandler : IExceptionHandler<ValidationException, ValidationProblemDetails>
{
    public ValidationProblemDetails Handle(ValidationException exception)
    {
        var errorDetails = exception.Errors.GroupBy(ex => ex.PropertyName)
                                           .ToDictionary(k => k.First().FormattedMessagePlaceholderValues[nameof(ValidationFailure.PropertyName)] as string,
                                                         v => v.Select(m => m.ErrorMessage).ToArray());

        var validationProblemDetails = new ValidationProblemDetails
        {
            Status = (int)HttpStatusCode.BadRequest,
            Title = Constants.RequestHandling.Messages.ValidationExceptionTitle,
            Detail = Constants.RequestHandling.Messages.ValidationExceptionDetail
        };

        foreach (var errorDetail in errorDetails)
        {
            validationProblemDetails.Errors.Add(errorDetail.Key, errorDetail.Value);
        }

        return validationProblemDetails;
    }
}
