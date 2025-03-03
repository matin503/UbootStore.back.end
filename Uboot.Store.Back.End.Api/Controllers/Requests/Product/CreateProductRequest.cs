namespace Uboot.Store.Back.End.Api.Controllers.Requests.Product;

public class CreateProductRequest
{
    public string Title { get; set; }
    public int Price { get; set; }
    public int SubCategoryId { get; set; }
}
