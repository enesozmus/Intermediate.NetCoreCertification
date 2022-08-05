namespace Intermediate.Domain.Entities;

public class ApartmentType : BaseEntity
{
     public string Type { get; set; }
     public ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
}
