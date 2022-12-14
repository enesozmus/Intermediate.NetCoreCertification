using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentsOperations;

public class UpdateApartmentCommandRequest : IRequest<Result<Unit>>
{
     public int Id { get; set; }
     public int Floor { get; set; }
     public int DoorNumber { get; set; }
     public bool IsAvailable { get; set; }
     public int AppUserId { get; set; }
     public int BlockId { get; set; }
     public int ApartmentTypeId { get; set; }
}
