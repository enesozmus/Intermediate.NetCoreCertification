using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class RemoveMessageCommandRequest : IRequest<Result<Unit>>
{
     public int Id { get; set; }
}
