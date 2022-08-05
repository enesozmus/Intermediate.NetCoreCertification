using Intermediate.MVC.Models.Enums;

namespace Intermediate.MVC.Models;
public class UpdateBillCommandRequest
{
     public int Id { get; set; }
     public BillType BillType { get; set; }
     public WhichMonth WhichMonth { get; set; }
     public decimal AmountPayable { get; set; }
     public bool IsPaid { get; set; } = false;
     public DateTime DeadlineDate { get; set; }

     public int AppUserId { get; set; }
}
