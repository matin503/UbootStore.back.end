using AutoMapper;
using Uboot.Store.Back.End.Core.Models;
using Uboot.Store.Back.End.Domain.LogicServices;
using Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

namespace Uboot.Store.Back.End.Application.Component.SubCategory.Create;

internal class CreateSubCategoryHandler(ISubCategoryLogic _subCategoryLogic, IMapper _mapper) : IHandler<CreateSubCategoryParam, IResponse>
{
    public async Task<IResponse> Handle(CreateSubCategoryParam param, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<SubCategoryModel>(param);

        await _subCategoryLogic.InsertAsync(model);

        return ResponseFactory.Success();
    }
}
