namespace Uboot.Store.Back.End.Core.Models;

public class SubCategoryModel : AbaseModel
{
    public string Title { get; set; }

    //nav key
    public virtual ICollection<SubCategory> Product { get; set; }
}
