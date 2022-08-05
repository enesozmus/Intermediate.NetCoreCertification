using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BlocksOperations;

public class CreateBlockCommandRequest : IRequest<Result<Unit>>
{
     public string BlockName { get; set; }
     public string Address { get; set; }
     public int TotalFlats { get; set; }
     public int TotalFloors { get; set; }
}
