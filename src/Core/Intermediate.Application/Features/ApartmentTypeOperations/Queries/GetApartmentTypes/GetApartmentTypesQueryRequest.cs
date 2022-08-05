using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentTypesOperations;

public class GetApartmentTypesQueryRequest : IRequest<Result<IReadOnlyList<GetApartmentTypesQueryResponse>>> { }
