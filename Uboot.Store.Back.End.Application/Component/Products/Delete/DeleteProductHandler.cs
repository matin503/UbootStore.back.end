using Uboot.Store.Back.End.Domain.LogicServices;
using Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

namespace Uboot.Store.Back.End.Application.Component.Products.Delete;

internal class DeleteProductHandler(IProductLogic _productLogic):IHandler<DeleteProductParam, IResponse>
{
    public async Task<IResponse> Handle(DeleteProductParam param, CancellationToken cancellationToken)
    {
        await _productLogic.DeleteAsync(param.Id);

        return ResponseFactory.Success();
    }
}
