using Intermediate.Application.Results;
using Intermediate.Domain.Enums;
using MediatR;

namespace Intermediate.Application.Features.BillsOperations;

public class CreateBillCommandRequest : IRequest<Result<Unit>>
{
     public BillType BillType { get; set; }
     public WhichMonth WhichMonth { get; set; }
     public decimal AmountPayable { get; set; }
     public bool IsPaid { get; set; } = false;
     public DateTime DeadlineDate { get; set; }

     public int AppUserId { get; set; }
}
