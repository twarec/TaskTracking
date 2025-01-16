using System.Net;

namespace TaskTracking.Domain.Exceptions;

public class HttpException(HttpStatusCode statusCode) : Exception
{
    public readonly HttpStatusCode StatusCode = statusCode;
}
