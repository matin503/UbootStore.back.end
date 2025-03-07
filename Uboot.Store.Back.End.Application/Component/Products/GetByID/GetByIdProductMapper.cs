using AutoMapper;
using Uboot.Store.Back.End.Core.Models;

namespace Uboot.Store.Back.End.Application.Component.Products.GetByID;

public class GetByIdProductMapper:Profile
{
    public GetByIdProductMapper()
    {
        CreateMap<SubCategory, GetByIdProductResponse>();
    }
}
