using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

namespace Uboot.Store.Back.End.Application.Component.Products.Create
{
    public class CreateProductParam: IParam<IResponse>
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int SubCategoryId { get; set; }
    }
}
