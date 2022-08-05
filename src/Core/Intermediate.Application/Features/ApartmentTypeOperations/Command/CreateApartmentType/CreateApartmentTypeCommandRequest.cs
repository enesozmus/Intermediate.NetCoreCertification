using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentTypesOperations;

public class CreateApartmentTypeCommandRequest : IRequest<Result<Unit>>
{
     public string Type { get; set; }
}
