using Intermediate.Application.Features.ProfilesOperations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ProfilesController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetUser() => HandleResult(await Mediator.Send(new GetUserQueryRequest()));

     [HttpGet("userbills")]
     public async Task<IActionResult> GetUserBills() => HandleResult(await Mediator.Send(new GetUserBillsQueryRequest()));

     [HttpGet("userapartments")]
     public async Task<IActionResult> GetUserApartments() => HandleResult(await Mediator.Send(new GetUserApartmentsQueryRequest()));
}
