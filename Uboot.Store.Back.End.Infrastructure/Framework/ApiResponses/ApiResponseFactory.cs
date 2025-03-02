using Microsoft.AspNetCore.Http;

namespace Uboot.Store.Back.End.Infrastructure.Framework.ApiResponses;

public static class ApiResponseFactory
{
    public static IApiResponse CreateSuccess(string message = "Request process successfully.")
    {
        return new ApiResponse
        {
            StatusCode = StatusCodes.Status200OK,
            Message = message,
            IsSuccess = true
        };
    }

    public static IApiResponse CreateBadRequest(params string[] messages)
    {
        var response = new ApiResponse
        {
            StatusCode = StatusCodes.Status400BadRequest,
            IsSuccess = false,
        };

        response.Errors.AddRange(messages);

        return response;
    }

    public static IApiResponse CreateBadRequest(IEnumerable<string> messages)
    {
        var response = new ApiResponse
        {
            StatusCode = StatusCodes.Status400BadRequest,
            IsSuccess = false
        };

        response.Errors.AddRange(messages);

        return response;
    }

    public static IApiResponse CreateNotFound(string message)
    {
        return new ApiResponse
        {
            StatusCode = StatusCodes.Status404NotFound,
            Message = message,
            IsSuccess = false
        };
    }

    public static IApiResponse CreateUnauthorized(string message = "Unauthorized access.")
    {
        return new ApiResponse
        {
            StatusCode = StatusCodes.Status401Unauthorized,
            Message = message,
            IsSuccess = false
        };
    }

    public static IApiResponse<T> CreateSuccess<T>(T data, string message = "Request process successfully.")
    {
        return new ApiResponse<T>
        {
            StatusCode = StatusCodes.Status200OK,
            Message = message,
            Data = data,
            IsSuccess = true
        };
    }

    public static IApiResponse<T> CreateNotFound<T>(T data, string message = "Not Found")
    {
        return new ApiResponse<T>
        {
            StatusCode = StatusCodes.Status404NotFound,
            Message = message,
            Data = data,
            IsSuccess = false
        };
    }

    public static IApiResponse<T> CreateUnauthorized<T>(T data, string message = "Unauthorized access.")
    {
        return new ApiResponse<T>
        {
            StatusCode = StatusCodes.Status401Unauthorized,
            Message = message,
            Data = data,
            IsSuccess = false
        };
    }
}
