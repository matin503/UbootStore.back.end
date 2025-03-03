using Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

namespace Uboot.Store.Back.End.Application.Component.Products.Edit;

public class EditProductParam:IParam<IResponse>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public int SubCategoryId { get; set; }
}
