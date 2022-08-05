using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentTypesOperations;

public class GetApartmentTypeDetailQueryRequest : IRequest<Result<GetApartmentTypesQueryResponse>>
{
     public int Id { get; set; }
}
