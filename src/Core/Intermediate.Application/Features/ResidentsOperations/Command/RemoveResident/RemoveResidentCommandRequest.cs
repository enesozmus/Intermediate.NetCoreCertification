using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ResidentsOperations;

public class RemoveResidentCommandRequest : IRequest<Result<Unit>>
{
     public int Id { get; set; }
}
