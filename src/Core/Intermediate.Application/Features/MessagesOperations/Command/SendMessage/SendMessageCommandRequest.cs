using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class SendMessageCommandRequest : IRequest<Result<Unit>>
{
     public int SendUserId { get; set; }
     public int ReceiveUserId { get; set; }
     public string Text { get; set; }
     public bool IsLooked { get; set; } = false;
}
