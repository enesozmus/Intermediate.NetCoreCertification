using Intermediate.Application.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
     #region MediatR

     private IMediator _mediator;

     protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

     #endregion

     #region Http Response Codes

     protected ActionResult HandleResult<T>(Result<T> result)
     {
          if (result == null) return NotFound();

          if (result.IsSuccess && result.Value != null)
               return Ok(result.Value);

          if (result.IsSuccess && result.Value == null)
               return NotFound();

          return BadRequest(result.Error);
     }

     #endregion
}
