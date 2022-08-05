using Intermediate.Domain.Enums;

namespace Intermediate.Domain.Entities;

public class Bill : BaseEntity
{
     public BillType BillType { get; set; }
     public WhichMonth WhichMonth { get; set; }
     public decimal AmountPayable { get; set; }
     public bool IsPaid { get; set; } = false;
     public DateTime DeadlineDate { get; set; }

     public int AppUserId { get; set; }
     public AppUser AppUser { get; set; }
}