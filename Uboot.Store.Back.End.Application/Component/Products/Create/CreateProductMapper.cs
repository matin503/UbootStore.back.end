using AutoMapper;
using Uboot.Store.Back.End.Core.Models;

namespace Uboot.Store.Back.End.Application.Component.Products.Create;

public class CreateProductMapper:Profile
{
    public CreateProductMapper()
    {
        CreateMap<CreateProductParam, ProductModel>();
    }
}
