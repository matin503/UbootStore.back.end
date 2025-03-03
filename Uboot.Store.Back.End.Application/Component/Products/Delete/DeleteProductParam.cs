using Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

namespace Uboot.Store.Back.End.Application.Component.Products.Delete
{
    public class DeleteProductParam : IParam<IResponse>
    {
        public int Id { get; set; }
    }
}
