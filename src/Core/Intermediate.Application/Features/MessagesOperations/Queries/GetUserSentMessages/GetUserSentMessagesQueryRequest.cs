using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class GetSentMessagesQueryRequest : IRequest<Result<IReadOnlyList<GetSentMessagesQueryResponse>>> { }
