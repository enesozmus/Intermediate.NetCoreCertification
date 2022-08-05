namespace Intermediate.Domain.Entities;

public class Block : BaseEntity
{
     public string BlockName { get; set; }
     public string Address { get; set; }
     public int TotalFlats { get; set; }
     public int TotalFloors { get; set; }
     public ICollection<Apartment> Apartments { get; set; } = new HashSet<Apartment>();
}
