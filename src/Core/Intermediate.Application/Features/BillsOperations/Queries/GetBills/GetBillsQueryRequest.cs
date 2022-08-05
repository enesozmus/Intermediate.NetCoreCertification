using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BillsOperations;

public class GetBillsQueryRequest : IRequest<Result<IReadOnlyList<GetBillsQueryResponse>>> { }
