using AutoMapper;
using Uboot.Store.Back.End.Core.Models;

namespace Uboot.Store.Back.End.Application.Component.Products.GetAll;

public class GetAllProductMapper : Profile
{
    public GetAllProductMapper()
    {
        CreateMap<ProductModel, GetAllProductResponse>();
    }
}
