using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ProfilesOperations;

public class GetUserBillsQueryRequest : IRequest<Result<IReadOnlyList<GetUserBillsQueryResponse>>> { }
