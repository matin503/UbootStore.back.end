namespace Uboot.Store.Back.End.Core.Models;

public abstract class AbaseModel
{
    public int Id { get; set; }
    public DateTime UpdateTime { get; set; } = DateTime.Now;
    public DateTime CreateTime { get; set; } = DateTime.Now;

}
