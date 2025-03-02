namespace Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

public class ResponseFactory
{
    public static IResponse Success(string message = "")
    {
        return new Response
        {
            Status = Status.Success,
            Messages = message.ToEnumerable()
        };
    }

    public static async Task<IResponse<T>> Success<T>(T data, string message = "")
    {
        return new Response<T>
        {
            Status = Status.Success,
            Messages = message.ToEnumerable(),
            Data = data
        };
    }

    public static async Task<IResponsePagination<T>> Success<T>(T data, int totalItems, string message = "")
    {
        return new ResponsePagination<T>
        {
            Status = Status.Success,
            Messages = message.ToEnumerable(),
            Data = data,
            TotalItems = totalItems
        };
    }

    public static IResponse BadRequest(params string[] messages)
    {
        return new Response
        {
            Status = Status.BadRequest,
            Messages = messages
        };
    }

    public static IResponse BadRequest(IEnumerable<string> messages)
    {
        return new Response
        {
            Status = Status.BadRequest,
            Messages = messages
        };
    }

    public static IResponse<T> BadRequest<T>(IEnumerable<string> messages)
    {
        return new Response<T>
        {
            Status = Status.BadRequest,
            Messages = messages,
            Data = default
        };
    }

    public static IResponse<T> BadRequest<T>(params string[] messages)
    {
        return new Response<T>
        {
            Status = Status.BadRequest,
            Messages = messages,
            Data = default
        };
    }

    public static IResponse NotFound(string message)
    {
        return new Response
        {
            Status = Status.NotFound,
            Messages = message.ToEnumerable()
        };
    }

    public static IResponse<T> NotFound<T>(string message)
    {
        return new Response<T>
        {
            Status = Status.NotFound,
            Messages = message.ToEnumerable(),
            Data = default
        };
    }

    public static IResponse<T> NotFound<T>(T data, string message = "")
    {
        return new Response<T>
        {
            Status = Status.NotFound,
            Messages = message.ToEnumerable(),
            Data = data
        };
    }


    public static IResponse Unauthorized(string message = "")
    {
        return new Response
        {
            Status = Status.Unauthorized,
            Messages = message.ToEnumerable()
        };
    }

    public static IResponse<T> Unauthorized<T>(string message = "")
    {
        return new Response<T>
        {
            Status = Status.Unauthorized,
            Messages = message.ToEnumerable(),
            Data = default
        };
    }

    public static IResponse<T> Unauthorized<T>(T data, string message = "")
    {
        return new Response<T>
        {
            Status = Status.Unauthorized,
            Messages = message.ToEnumerable(),
            Data = data
        };
    }

    public static IResponse InternalError(string message = "")
    {
        return new Response
        {
            Status = Status.InternalError,
            Messages = message.ToEnumerable()
        };
    }

    public static IResponse<T> InternalError<T>(string message = "")
    {
        return new Response<T>
        {
            Status = Status.InternalError,
            Messages = message.ToEnumerable(),
            Data = default
        };
    }
}
