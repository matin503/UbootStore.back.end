using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

public interface IResponsePagination
{
    Status Status { get; }

    IEnumerable<string> Messages { get; }
}

public interface IResponsePagination<out T> : IResponsePagination
{
    T Data { get; }

    int TotalItems { get; }
}
