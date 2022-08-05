using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ProfilesOperations;

public class GetUserApartmentsQueryRequest : IRequest<Result<IReadOnlyList<GetUserApartmentsQueryResponse>>> { }
