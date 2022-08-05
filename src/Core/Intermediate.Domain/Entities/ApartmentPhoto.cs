namespace Intermediate.Domain.Entities;

public class ApartmentPhoto : BasePhoto
{
     public int ApartmentId { get; set; }
     public Apartment Apartment { get; set; }
}
