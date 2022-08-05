namespace Intermediate.Application.Features.ApartmentsOperations;

public class GetApartmentsQueryResponse
{
     public int Id { get; set; }
     public int Floor { get; set; }
     public int DoorNumber { get; set; }
     public bool IsAvailable { get; set; }
     public int AppUserId { get; set; }
     public string AppUser { get; set; }
     public int BlockId { get; set; }
     public string BlockName { get; set; }
     public int ApartmentTypeId { get; set; }
     public string ApartmentType { get; set; }
}
