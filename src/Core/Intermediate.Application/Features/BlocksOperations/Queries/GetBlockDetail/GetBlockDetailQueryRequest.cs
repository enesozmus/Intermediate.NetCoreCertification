using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BlocksOperations;

public class GetBlockDetailQueryRequest : IRequest<Result<GetBlocksQueryResponse>>
{
     public int Id { get; set; }
}
