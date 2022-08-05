using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentTypesOperations;

public class UpdateApartmentTypeCommandRequest : IRequest<Result<Unit>>
{
     public int Id { get; set; }
     public string Type { get; set; }
}
