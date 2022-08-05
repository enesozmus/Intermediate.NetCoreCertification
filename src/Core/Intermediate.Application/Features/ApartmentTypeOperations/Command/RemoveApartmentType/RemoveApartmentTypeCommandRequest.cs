using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentTypesOperations;

public class RemoveApartmentTypeCommandRequest : IRequest<Result<Unit>>
{
     public int Id { get; set; }
}
