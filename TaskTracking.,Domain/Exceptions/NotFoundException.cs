using System.Net;

namespace TaskTracking.Domain.Exceptions;

public class NotFoundException : HttpException
{
    public NotFoundException() : base(HttpStatusCode.NotFound)
    {

    }
}
