using Microsoft.AspNetCore.Mvc;
using Online.Menu.InfraStructure.Framework.ApiResponses;


namespace Uboot.Store.Back.End.Infrastructure.Framework.ApiOptions
{
    public static class ConfigureApiBehavior
    {
        public static void InvalidResponseFactory(this ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var messages = context.ModelState.Keys
                     .SelectMany(key => context.ModelState[key].Errors.Select(x => $"{x.ErrorMessage}"));

                var result = ApiResponseFactory.CreateBadRequest(messages);

                return result;
            };
        }
    }
}
