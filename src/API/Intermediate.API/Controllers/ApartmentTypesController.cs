using Intermediate.Application.Features.ApartmentTypesOperations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Authorize(Roles = "Admin")]
public class ApartmentTypesController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetApartmentTypes() => HandleResult(await Mediator.Send(new GetApartmentTypesQueryRequest()));

     [HttpGet("{id}")]
     public async Task<IActionResult> GetApartmentType(int id) => HandleResult(await Mediator.Send(new GetApartmentTypeDetailQueryRequest { Id = id }));

     [HttpPost]
     public async Task<IActionResult> CreateApartmentType(CreateApartmentTypeCommandRequest request) => HandleResult(await Mediator.Send(request));

     [HttpPut]
     public async Task<IActionResult> UpdateApartmentType(UpdateApartmentTypeCommandRequest request) => HandleResult(await Mediator.Send(request));

     [HttpDelete("{id}")]
     public async Task<IActionResult> RemoveApartmentType(int id) => HandleResult(await Mediator.Send( new RemoveApartmentTypeCommandRequest{ Id = id}));
}
