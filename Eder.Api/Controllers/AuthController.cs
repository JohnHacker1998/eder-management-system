using Eder.Application.Auth.Commands;
using Eder.Application.Auth.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eder.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(ISender sender) : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<RegisterResponse>> Register(
        [FromBody] RegisterRequest request,
        CancellationToken cancellationToken
    )
    {
        var response = await sender.Send(new CreateUserCommand(request), cancellationToken);
        return StatusCode(StatusCodes.Status201Created, response);
    }
}
