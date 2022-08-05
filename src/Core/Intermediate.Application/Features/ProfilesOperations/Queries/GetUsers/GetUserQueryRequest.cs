using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ProfilesOperations;

public class GetUserQueryRequest : IRequest<Result<GetUserQueryResponse>> { }
