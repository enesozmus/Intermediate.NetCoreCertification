using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BlocksOperations;

public class GetBlocksQueryRequest : IRequest<Result<IReadOnlyList<GetBlocksQueryResponse>>> { }
