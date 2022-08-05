using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class UpdateMessageCommandRequest : IRequest<Result<Unit>>
{
     public int Id { get; set; }
     public string Text { get; set; }
     public bool IsLooked { get; set; }
}
