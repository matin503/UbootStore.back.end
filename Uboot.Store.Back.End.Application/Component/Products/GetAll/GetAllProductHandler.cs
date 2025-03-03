using AutoMapper;
using Uboot.Store.Back.End.Domain.LogicServices;
using Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

namespace Uboot.Store.Back.End.Application.Component.Products.GetAll;

internal class GetAllProductHandler(IProductLogic _productLogic, IMapper _mapper):IHandler<GetAllProductParam,IResponse<ICollection<GetAllProductResponse>>>
{
    public async Task<IResponse<ICollection<GetAllProductResponse>>> Handle(GetAllProductParam param, CancellationToken cancellationToken)
    {
        var models = await _productLogic.GetAllAsync();

        var response = _mapper.Map<GetAllProductResponse[]>(models);

        return await ResponseFactory.Success(response);
    }
}
