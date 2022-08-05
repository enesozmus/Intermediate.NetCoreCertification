using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BlocksOperations;

public class UpdateBlockCommandRequest : IRequest<Result<Unit>>
{
     public int Id { get; set; }
     public string BlockName { get; set; }
     public string Address { get; set; }
     public int TotalFlats { get; set; }
     public int TotalFloors { get; set; }
}
