namespace Intermediate.Domain.Entities;

public class Apartment : BaseEntity
{
     public int Floor { get; set; }
     public int DoorNumber { get; set; }
     public bool IsAvailable { get; set; }

     public int AppUserId { get; set; }
     public AppUser AppUser { get; set; }

     public int BlockId { get; set; }
     public Block Block { get; set; }

     public int ApartmentTypeId { get; set; }
     public ApartmentType ApartmentType { get; set; }
}
