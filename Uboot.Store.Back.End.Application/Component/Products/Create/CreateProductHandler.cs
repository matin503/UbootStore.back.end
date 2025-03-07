using AutoMapper;
using Uboot.Store.Back.End.Core.Models;
using Uboot.Store.Back.End.Domain.LogicServices;
using Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

namespace Uboot.Store.Back.End.Application.Component.Products.Create;

internal class CreateProductHandler(IProductLogic _productLogic, IMapper _mapper):IHandler<CreateProductParam,IResponse>
{
    public async Task<IResponse> Handle(CreateProductParam param, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<SubCategory>(param);

        await _productLogic.InsertAsync(model);

        return ResponseFactory.Success();
    }
}
