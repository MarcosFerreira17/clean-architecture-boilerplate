using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Template.Application.Exceptions.Model;
using Template.Application.Features.Commands.CreateTemplate;
using Template.Application.Features.Commands.DeleteTemplate;
using Template.Application.Features.Commands.UpdateTemplate;
using Template.Application.Features.Queries.GetTemplateList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Template.Application.Features.Queries.GetTemplateById;

namespace Template.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TemplateController : ControllerBase
{
    private readonly IMediator _mediator;

    public TemplateController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet(Name = "GetTemplate")]
    [ProducesResponseType(typeof(IEnumerable<EntityDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<EntityDto>>> GetAll()
    {
        var query = new GetAllTemplateQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> GetById(long id)
    {
        var query = new GetTemplateByIdQuery(id);
        var result = await _mediator.Send(query);

        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost(Name = "CreateTemplate")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<long>> CreateTemplate([FromBody] CreateTemplateCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new Response<long>(result, $"Successfully created with Id: {result}"));
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
    public async Task<ActionResult> Delete(long id)
    {
        var command = new DeleteTemplateCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}