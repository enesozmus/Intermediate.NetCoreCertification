using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BillsOperations;

public class GetBillDetailQueryRequest : IRequest<Result<GetBillsQueryResponse>>
{
     public int Id { get; set; }
}
