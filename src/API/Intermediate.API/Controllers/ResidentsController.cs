using Intermediate.Application.Features.ResidentsOperations;
using Intermediate.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intermediate.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Authorize(Roles = "Admin")]
public class ResidentsController : BaseController
{
     private readonly UserManager<AppUser> _userManager;

     public ResidentsController(UserManager<AppUser> userManager)
     {
          _userManager = userManager;
     }

     [HttpGet]
     public async Task<IActionResult> GetResidents() => HandleResult(await Mediator.Send(new GetResidentsQueryRequest()));

     [HttpGet("names")]
     public async Task<IActionResult> GetResidentNames() => HandleResult(await Mediator.Send(new GetResidentNamesQueryRequest()));

     [HttpGet("{id}")]
     public async Task<IActionResult> GetResident(int id) => HandleResult(await Mediator.Send(new GetResidentDetailQueryRequest { Id = id }));

     [HttpPost]
     //[HttpPost("register")]
     public async Task<IActionResult> CreateResident(CreateResidentCommandRequest request)
     {
          if (await _userManager.Users.AnyAsync(x => x.Email == request.Email))
          {
               ModelState.AddModelError("email", "Almaya çalıştığınız email zaten alınmış. Lütfen başka bir email deneyiniz!");
               return ValidationProblem();
          }

          if (await _userManager.Users.AnyAsync(x => x.UserName == request.UserName))
          {
               ModelState.AddModelError("username", "Almaya çalıştığınız kullanıcı adı zaten alınmış. Lütfen başka bir kullanıcı adı deneyiniz!");
               return ValidationProblem();
          }

          return HandleResult(await Mediator.Send(request));
     }

     [HttpPut]
     public async Task<IActionResult> UpdateResident(UpdateResidentCommandRequest request) => HandleResult(await Mediator.Send(request));

     [HttpDelete("{id}")]
     public async Task<IActionResult> RemoveResident(int id) => HandleResult(await Mediator.Send(new RemoveResidentCommandRequest { Id = id }));
}
