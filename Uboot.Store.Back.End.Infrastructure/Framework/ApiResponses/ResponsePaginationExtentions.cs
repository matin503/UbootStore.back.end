namespace Uboot.Store.Back.End.Infrastructure.Framework.ApiResponses;

public static class ResponsePaginationExtentions
{
    public static IApiResponsePagination ToApiResponsePagination(this IResponsePagination queryResponse)
    {
        var isSuccess = queryResponse.Status == Status.Success;
        var statusCode = queryResponse.Status.ToHttpStatusCode();
        var message = ResponseHaveMessage(queryResponse.Messages) ? queryResponse.Messages.FirstOrDefault() : string.Empty;

        var response = new ApiResponsePagination()
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

    public static IApiResponsePagination ToApiResponsePagination<T>(this IResponsePagination<T> queryResponse)
    {
        var isSuccess = queryResponse.Status == Status.Success;
        var statusCode = queryResponse.Status.ToHttpStatusCode();
        var message = ResponseHaveMessage(queryResponse.Messages) ? queryResponse.Messages.FirstOrDefault() : string.Empty;

        var response = new ApiResponsePagination<T>()
        {
            IsSuccess = isSuccess,
            StatusCode = statusCode,
            Message = message,
            Data = queryResponse.Data,
            TotalItems = queryResponse.TotalItems,
        };

        if (!isSuccess)
        {
            response.Errors.AddRange(queryResponse.Messages);
        }

        return response;
    }

    private static bool ResponseHaveMessage(IEnumerable<string> responseMessage) => responseMessage.IsNullOrEmpty() == false && responseMessage.Count() == 1;
}
