using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentsOperations;

public class GetApartmentDetailQueryRequest : IRequest<Result<GetApartmentsQueryResponse>>
{
     public int Id { get; set; }
}
