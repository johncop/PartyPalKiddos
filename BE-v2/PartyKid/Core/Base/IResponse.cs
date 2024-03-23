using System.Net;

namespace PartyKid;

public interface IResponse
{
    HttpStatusCode StatusCode { get; }
    string Message { get; }
}

public interface IResponse<T> : IResponse
{
    public T Data { get; }
}
