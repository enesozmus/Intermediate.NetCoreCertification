using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class GetIncomingMessagesQueryRequest : IRequest<Result<IReadOnlyList<GetIncomingMessagesQueryResponse>>> { }
