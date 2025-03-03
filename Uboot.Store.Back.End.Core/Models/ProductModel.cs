using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uboot.Store.Back.End.Core.Models
{
    public class ProductModel : AbaseModel
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int SubCategoryId { get; set; }

    }
}
