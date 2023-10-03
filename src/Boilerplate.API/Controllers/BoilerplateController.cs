using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Boilerplate.Application.RequestFeatures;
using Boilerplate.Domain.Dtos;
using Boilerplate.Application.Services.Interfaces;

namespace Boilerplate.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BoilerplateController : ControllerBase
{
    private readonly IBoilerplateService _service;

    public BoilerplateController(IBoilerplateService service)
    {
        _service = service;
    }

#nullable enable
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(PagedList<BoilerplateDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetAll([FromQuery] BoilerplateParameters? BoilerplateParameters)
    {
        var entitiesFromDb = await _service.PagedGetAll(BoilerplateParameters);
        Response.Headers.Add("X-Pagination",
            JsonConvert.SerializeObject(entitiesFromDb.MetaData));

        return Ok(entitiesFromDb);
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetById(long id)
    {
        var entityFromDb = await _service.GetById(id);
        return Ok(entityFromDb);
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StatusCodeResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> Create([FromBody] BoilerplateDto addDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _service.Create(addDto);
        return Ok();
    }

    [HttpPut("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] BoilerplateDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _service.Update(id, updateDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> RemoveAsync(long id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}