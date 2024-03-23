using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

public interface IExceptionHandler<in TException, out TOuput> where TException : Exception where TOuput : ProblemDetails
{
    TOuput Handle(TException exception);
}
