using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BlocksOperations;

public class RemoveBlockCommandRequest : IRequest<Result<Unit>>
{
     public int Id { get; set; }
}
