using Intermediate.Application.Features.ApartmentsOperations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class ApartmentsController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetApartments() => HandleResult(await Mediator.Send(new GetApartmentsQueryRequest()));

     [HttpGet("{id}")]
     public async Task<IActionResult> GetApartment(int id) => HandleResult(await Mediator.Send(new GetApartmentDetailQueryRequest { Id = id }));

     [Authorize(Roles = "Admin")]
     [HttpPost]
     public async Task<IActionResult> CreateApartment(CreateApartmentCommandRequest request) => HandleResult(await Mediator.Send(request));

     [Authorize(Roles = "Admin")]
     [HttpPut]
     public async Task<IActionResult> UpdateApartment(UpdateApartmentCommandRequest request) => HandleResult(await Mediator.Send(request));

     [Authorize(Roles = "Admin")]
     [HttpDelete("{id}")]
     public async Task<IActionResult> RemoveApartment(int id) => HandleResult(await Mediator.Send( new RemoveApartmentCommandRequest{ Id = id}));
}
