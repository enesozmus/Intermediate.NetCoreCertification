using Intermediate.Application.Features.BillsOperations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BillsController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetBills() => HandleResult(await Mediator.Send(new GetBillsQueryRequest()));

     [HttpGet("{id}")]
     public async Task<IActionResult> GetBill(int id) => HandleResult(await Mediator.Send(new GetBillDetailQueryRequest { Id = id }));


     [Authorize(Roles = "Admin")]
     [HttpPost]
     public async Task<IActionResult> CreateBill(CreateBillCommandRequest request) => HandleResult(await Mediator.Send(request));

     [Authorize(Roles = "Admin")]
     [HttpPut]
     public async Task<IActionResult> UpdateBill(UpdateBillCommandRequest request) => HandleResult(await Mediator.Send(request));

     [Authorize(Roles = "Admin")]
     [HttpPut("{id}")]
     public async Task<IActionResult> UpdateBillForIsPaid(int id) => HandleResult(await Mediator.Send(new PayTheBillCommandRequest { Id = id }));

     [Authorize(Roles = "Admin")]
     [HttpDelete("{id}")]
     public async Task<IActionResult> RemoveBill(int id) => HandleResult(await Mediator.Send(new RemoveBillCommandRequest { Id = id }));
}
