using MediatR;

namespace Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

public interface IParam : IRequest
{
}

public interface IParam<T> : IRequest<T>
{
}
