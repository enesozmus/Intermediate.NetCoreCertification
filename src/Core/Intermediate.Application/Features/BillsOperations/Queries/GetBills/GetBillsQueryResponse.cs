namespace Intermediate.Application.Features.BillsOperations;

public class GetBillsQueryResponse
{
     public int Id { get; set; }
     public string BillType { get; set; }
     public string WhichMonth { get; set; }
     public decimal AmountPayable { get; set; }
     public bool IsPaid { get; set; } = false;
     public DateTime DeadlineDate { get; set; }

     public string Payer { get; set; }
     public int AppUserId { get; set; }
}
