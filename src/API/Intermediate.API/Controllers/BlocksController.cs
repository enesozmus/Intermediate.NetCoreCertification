using Intermediate.Application.Features.BlocksOperations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Authorize(Roles = "Admin")]
public class BlocksController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetBlocks() => HandleResult(await Mediator.Send(new GetBlocksQueryRequest()));

     [HttpGet("{id}")]
     public async Task<IActionResult> GetBlock(int id) => HandleResult(await Mediator.Send(new GetBlockDetailQueryRequest { Id = id }));

     [HttpPost]
     public async Task<IActionResult> CreateBlock(CreateBlockCommandRequest request) => HandleResult(await Mediator.Send(request));

     [HttpPut]
     public async Task<IActionResult> UpdateBlock(UpdateBlockCommandRequest request) => HandleResult(await Mediator.Send(request));

     [HttpDelete("{id}")]
     public async Task<IActionResult> RemoveBlock(int id) => HandleResult(await Mediator.Send( new RemoveBlockCommandRequest{ Id = id}));
}
