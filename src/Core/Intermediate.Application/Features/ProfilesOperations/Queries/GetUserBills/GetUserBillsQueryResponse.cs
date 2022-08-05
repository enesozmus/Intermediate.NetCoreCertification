namespace Intermediate.Application.Features.ProfilesOperations;

public class GetUserBillsQueryResponse
{
     public int Id { get; set; }
     public string BillType { get; set; }
     public string WhichMonth { get; set; }
     public decimal AmountPayable { get; set; }
     public bool IsPaid { get; set; } = false;
     public DateTime DeadlineDate { get; set; }
}