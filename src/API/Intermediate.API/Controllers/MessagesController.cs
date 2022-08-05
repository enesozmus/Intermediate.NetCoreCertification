using Intermediate.Application.Features.MessagesOperations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class MessagesController : BaseController
{
     
     [HttpGet("sentmessages")]
     public async Task<IActionResult> GetSentMessages() => HandleResult(await Mediator.Send(new GetSentMessagesQueryRequest()));

     [HttpGet("incomingmessages")]
     public async Task<IActionResult> GetIncomingMessages() => HandleResult(await Mediator.Send(new GetIncomingMessagesQueryRequest()));

     [HttpGet("{id}")]
     public async Task<IActionResult> GetMessage(int id) => HandleResult(await Mediator.Send(new GetMessageDetailQueryRequest { Id = id }));

     [HttpPost]
     public async Task<IActionResult> SendMessage(SendMessageCommandRequest request) => HandleResult(await Mediator.Send(request));

     [HttpDelete("{id}")]
     public async Task<IActionResult> RemoveMessage(int id) => HandleResult(await Mediator.Send(new RemoveMessageCommandRequest { Id = id }));

     [HttpPut]
     public async Task<IActionResult> UpdateMessage(UpdateMessageCommandRequest request) => HandleResult(await Mediator.Send(request));
}
