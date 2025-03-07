using AutoMapper;
using Uboot.Store.Back.End.Core.Models;

namespace Uboot.Store.Back.End.Application.Component.Products.Edit;

public class EditProductMapper: Profile
{
    public EditProductMapper()
    {
        CreateMap<EditProductParam, SubCategory>();
    }
}
