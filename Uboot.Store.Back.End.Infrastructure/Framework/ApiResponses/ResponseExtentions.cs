namespace Uboot.Store.Back.End.Infrastructure.Framework.ApiResponses;

public static class ResponseExtentions
{
    public static IApiResponse ToApiResponse(this IResponse queryResponse)
    {
        var isSuccess = queryResponse.Status == Status.Success;
        var statusCode = queryResponse.Status.ToHttpStatusCode();
        var message = ResponseHaveMessage(queryResponse.Messages) ? queryResponse.Messages.FirstOrDefault() : string.Empty;

        var response = new ApiResponse()
        {
            IsSuccess = isSuccess,
            StatusCode = statusCode,
            Message = message,
        };

        if (!isSuccess)
        {
            response.Errors.AddRange(queryResponse.Messages);
        }

        return response;
    }

    public static IApiResponse ToApiResponse<T>(this IResponse<T> queryResponse)
    {
        var isSuccess = queryResponse.Status == Status.Success;
        var statusCode = queryResponse.Status.ToHttpStatusCode();
        var message = ResponseHaveMessage(queryResponse.Messages) ? queryResponse.Messages.FirstOrDefault() : string.Empty;

        var response = new ApiResponse<T>()
        {
            IsSuccess = isSuccess,
            StatusCode = statusCode,
            Message = message,
            Data = queryResponse.Data,
        };

        if (!isSuccess)
        {
            response.Errors.AddRange(queryResponse.Messages);
        }

        return response;
    }

    private static bool ResponseHaveMessage(IEnumerable<string> responseMessage) => responseMessage.IsNullOrEmpty() == false && responseMessage.Count() == 1;
}
