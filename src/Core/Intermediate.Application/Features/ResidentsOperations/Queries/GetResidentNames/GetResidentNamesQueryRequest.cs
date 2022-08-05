using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ResidentsOperations;

public class GetResidentNamesQueryRequest : IRequest<Result<IReadOnlyList<GetResidentNamesQueryResponse>>> { }
