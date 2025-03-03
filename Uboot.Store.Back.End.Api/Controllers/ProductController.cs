using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Uboot.Store.Back.End.Api.Controllers.Requests.Product;
using Uboot.Store.Back.End.Application.Component.Products.Create;
using Uboot.Store.Back.End.Application.Component.Products.Delete;
using Uboot.Store.Back.End.Application.Component.Products.Edit;
using Uboot.Store.Back.End.Application.Component.Products.GetAll;
using Uboot.Store.Back.End.Application.Component.Products.GetByID;
using Uboot.Store.Back.End.Infrastructure.Framework.ApiResponses;

namespace Uboot.Store.Back.End.Api.Controllers;

[Route("api/Products")]
[ApiController]
public class ProductController(IMediator _mediator) : BaseController
{
    [HttpPost]
    [SwaggerOperation(Summary = "", Description = "")]
    [SwaggerResponse(200, "")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductRequest request)
    {
        var param = new CreateProductParam
        {
            SubCategoryId=request.SubCategoryId,
            Price = request.Price,
            Title = request.Title,
        };

        var response = await _mediator.Send(param);

        return response.ToApiResponse();
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "", Description = "")]
    [SwaggerResponse(200, "")]
    public async Task<IActionResult> EditAsync([FromRoute] int id, [FromBody] EditProductRequest request)
    {
        var param = new EditProductParam
        {
            Id = id,
            Price =request.Price,
            SubCategoryId = request.SubCategoryId,
            Title = request.Title,
        };

        var response = await _mediator.Send(param);

        return response.ToApiResponse();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "", Description = "")]
    [SwaggerResponse(200, "")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var param = new DeleteProductParam
        {
            Id = id
        };

        var response = await _mediator.Send(param);

        return response.ToApiResponse();
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "", Description = "")]
    [SwaggerResponse(200, "", typeof(GetByIdProductResponse))]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var param = new GetByIdProductParam
        {
            Id = id
        };

        var response = await _mediator.Send(param);

        return response.ToApiResponse();
    }

    [HttpGet]
    [SwaggerOperation(Summary = "", Description = "")]
    [SwaggerResponse(200, "", typeof(ICollection<GetAllProductResponse>))]
    public async Task<IActionResult> GetAsync()
    {
        var param = new GetAllProductParam();

        var response = await _mediator.Send(param);

        return response.ToApiResponse();
    }
}
