using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ResidentsOperations;

public class GetResidentsQueryRequest : IRequest<Result<IReadOnlyList<GetResidentsQueryResponse>>> { }
