using System;
using System.Net;
using System.Threading.Tasks;
using Application.Features.Commands.CreateTemplate;
using Application.Features.Commands.DeleteTemplate;
using Application.Features.Commands.UpdateTemplate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TemplateController : ControllerBase
{
    private readonly IMediator _mediator;

    public TemplateController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    // [HttpGet("{userName}", Name = "GetOrder")]
    // [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
    // public async Task<ActionResult<IEnumerable<OrdersVm>>> GetOrdersByUserName(string userName)
    // {
    //     var query = new GetOrdersListQuery(userName);
    //     var orders = await _mediator.Send(query);
    //     return Ok(orders);
    // }

    // testing purpose
    [HttpPost(Name = "CreateTemplate")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<long>> CreateTemplate([FromBody] CreateTemplateCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut(Name = "Update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateTemplateCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "Delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTemplateCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}