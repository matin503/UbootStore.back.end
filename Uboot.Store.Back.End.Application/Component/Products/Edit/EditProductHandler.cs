using AutoMapper;
using Uboot.Store.Back.End.Core.Models;
using Uboot.Store.Back.End.Domain.LogicServices;
using Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

namespace Uboot.Store.Back.End.Application.Component.Products.Edit;

internal class EditProductHandler(IProductLogic _productLogic, IMapper _mapper) :IHandler<EditProductParam, IResponse>
{
    public async Task<IResponse> Handle(EditProductParam param, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<SubCategory>(param);

        await _productLogic.UpdateAsync(model);

        return ResponseFactory.Success();
    }
}
