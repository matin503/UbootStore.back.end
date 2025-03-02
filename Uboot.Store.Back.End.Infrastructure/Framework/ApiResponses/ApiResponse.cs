using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Uboot.Store.Back.End.Infrastructure.Framework.ApiResponses;

public class ApiResponse : IApiResponse
{
    private bool isSuccess = true;

    public int StatusCode { get; set; }

    public string Message { get; set; }

    public bool IsSuccess
    {
        get => isSuccess && Errors.Count == 0;
        set => isSuccess = value;
    }

    public List<string> Errors { get; private set; } = [];

    public static implicit operator ActionResult(ApiResponse data)
    {
        return new ObjectResult(data);
    }

    public static implicit operator ObjectResult(ApiResponse data)
    {
        return new ObjectResult(data);
    }

    public void AddError(string errorMessage)
    {
        Errors ??= [];

        Errors.Add(errorMessage);

        IsSuccess = false;
    }

    public void AddError(IEnumerable<string> errorMessage)
    {
        Errors ??= [];

        Errors.AddRange(errorMessage);

        IsSuccess = false;
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var actionResult = new ObjectResult(this)
        {
            StatusCode = StatusCode
        };
        await actionResult.ExecuteResultAsync(context);
    }

    public static ApiResponse CreateInvalidModelStateMessage(ModelStateDictionary modelState, string message = "خطای اعتبار سنجی ورودی ها")
    {
        var response = new ApiResponse()
        {
            IsSuccess = false,
            Message = message,
        };

        var errorMessages = modelState.GetErrors();

        response.AddError(errorMessages);

        return response;
    }
}

public class ApiResponse<T> : ApiResponse, IApiResponse<T>
{
    public T Data { get; set; }

    public static implicit operator ActionResult(ApiResponse<T> data)
    {
        return new ObjectResult(data);
    }

    public static implicit operator ObjectResult(ApiResponse<T> data)
    {
        return new ObjectResult(data);
    }
}
