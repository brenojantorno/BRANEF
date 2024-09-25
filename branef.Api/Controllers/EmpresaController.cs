using branef.Application.Members.Commands;
using branef.Application.Members.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace branef.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpresaController(IMediator _mediator) : ControllerBase
{

    [HttpGet("{Id}")]
    [Produces("application/json")]
    public async Task<IActionResult> GetEmpresa(Guid Id) => Ok(await _mediator.Send(new EmpresaIdQuery(Id)));

    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> GetEmpresas() => Ok(await _mediator.Send(new EmpresaQuery()));

    [HttpPost]
    [Produces("application/json")]
    public async Task<IActionResult> Insert([FromBody] EmpresaCommand command, CancellationToken ct)
    {
        var result = await _mediator.Send(command, ct);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    [Produces("application/json")]
    public async Task<ActionResult> Update([FromBody] UpdateEmpresaCommand command, CancellationToken ct)
    {
        var result = await _mediator.Send(command, ct);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult> Delete(Guid Id, CancellationToken ct)
    {
        var result = await _mediator.Send(new DeleteEmpresaCommand(Id), ct);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}