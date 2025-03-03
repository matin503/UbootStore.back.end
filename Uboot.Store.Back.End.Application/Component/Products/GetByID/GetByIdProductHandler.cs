using AutoMapper;
using Uboot.Store.Back.End.Domain.LogicServices;
using Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

namespace Uboot.Store.Back.End.Application.Component.Products.GetByID;

internal class GetByIdProductHandler(IProductLogic _productLogic, IMapper _mapper) : IHandler<GetByIdProductParam, IResponse<GetByIdProductResponse>>
{
   public async Task<IResponse<GetByIdProductResponse>> Handle(GetByIdProductParam param, CancellationToken cancellationToken)
    {
        var result = await _productLogic.GetByIdAsync(param.Id);

        var response = _mapper.Map<GetByIdProductResponse>(result);

        return await ResponseFactory.Success(response);
    }
}
