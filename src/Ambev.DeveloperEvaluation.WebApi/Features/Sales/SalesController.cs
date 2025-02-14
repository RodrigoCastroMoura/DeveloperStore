
using Ambev.DeveloperEvaluation.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;

    public SalesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponseWithData<GetSaleResult>>> Get([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetSaleQuery { Id = id });
        return new ActionResult<ApiResponseWithData<GetSaleResult>>(new ApiResponseWithData<GetSaleResult>(result));
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResult>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ApiResponseWithData<CreateSaleResult>>> Create([FromBody] CreateSaleCommand command)
    {
        var result = await _mediator.Send(command);
        var response = new ApiResponseWithData<CreateSaleResult>(result);
        return new ActionResult<ApiResponseWithData<CreateSaleResult>>(response);
    }

    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResult>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponseWithData<UpdateSaleResult>>> Update([FromRoute] Guid id, [FromBody] UpdateSaleCommand command)
    {
        if (id != command.Id)
            return new ActionResult<ApiResponseWithData<UpdateSaleResult>>(new ApiResponseWithData<UpdateSaleResult>());

        var result = await _mediator.Send(command);
        var response = new ApiResponseWithData<UpdateSaleResult>(result);
        return new ActionResult<ApiResponseWithData<UpdateSaleResult>>(response);
    }

    [HttpPost("{id}/cancel")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Cancel([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new CancelSaleCommand { Id = id });
        if (!result)
            return NotFound();

        return Ok(new ApiResponse("Sale cancelled successfully"));
    }

    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteSaleCommand { Id = id });
        return Ok(new ApiResponse("Sale deleted successfully"));
    }
}
