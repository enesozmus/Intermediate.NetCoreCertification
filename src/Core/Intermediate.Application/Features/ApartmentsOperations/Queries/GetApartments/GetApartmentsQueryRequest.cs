using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentsOperations;

public class GetApartmentsQueryRequest : IRequest<Result<IReadOnlyList<GetApartmentsQueryResponse>>> { }
