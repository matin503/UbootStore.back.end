namespace Uboot.Store.Back.End.Core.Models;

public class SubCategory : AbaseModel
{
    public string Title { get; set; }

    //nav key
    public virtual ICollection<ProductModel> Product { get; set; }
}
