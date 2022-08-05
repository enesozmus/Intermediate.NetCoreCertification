using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class GetMessageDetailQueryRequest : IRequest<Result<GetMessageDetailQueryResponse>>
{
     public int Id { get; set; }
}
