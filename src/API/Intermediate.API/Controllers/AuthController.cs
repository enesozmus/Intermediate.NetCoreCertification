using Intermediate.Application.Features.AuthenticationOperations;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.API.Controllers;

public class AuthController : BaseController
{
     [HttpPost("login")]
     public async Task<IActionResult> Login([FromBody] LoginCommandRequest request)
     {
          return Ok(await Mediator.Send(request));
          //var result = await Mediator.Send(request);
          //if (result.IsSuccess == false)
          //     return Unauthorized("Email veya şifre hatalı!");
          //return Ok(result);
     }
}
