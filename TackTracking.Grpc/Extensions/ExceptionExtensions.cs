using Grpc.Core;
using TaskTracking.Domain.Exceptions;

namespace TackTracking.Grpc.Extensions;

public static class ExceptionExtensions
{
    public static RpcException ToRpcException(this HttpException exception)
    {
        switch (exception)
        {
            case NotFoundException notFoundException:
                return notFoundException.ToRpcException();
        }

        return new RpcException(new Status(StatusCode.Internal, exception.Message));
    }

    public static RpcException ToRpcException(this NotFoundException exception)
    {
        return new RpcException(new Status(StatusCode.NotFound, exception.Message));
    }
}
