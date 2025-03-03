using Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

namespace Uboot.Store.Back.End.Application.Component.Products.GetByID;

public class GetByIdProductParam : IParam<IResponse<GetByIdProductResponse>>
{
    public int Id { get; set; }
}
