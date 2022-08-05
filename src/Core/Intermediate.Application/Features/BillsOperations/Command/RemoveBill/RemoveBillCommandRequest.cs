using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BillsOperations;

public class RemoveBillCommandRequest : IRequest<Result<Unit>>
{
     public int Id { get; set; }
}
