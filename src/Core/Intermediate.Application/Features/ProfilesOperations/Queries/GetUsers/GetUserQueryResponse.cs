using Intermediate.Domain.Entities;

namespace Intermediate.Application.Features.ProfilesOperations;

public class GetUserQueryResponse
{
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public string UserName { get; set; }
     public string Email { get; set; }
     public string PhoneNumber { get; set; }
     public string IdentityNumber { get; set; }
     public bool IsHirer { get; set; }
     public bool IsOwner { get; set; }
     public bool IsCarOwner { get; set; } = false;
     public string? CarPlate { get; set; }

     //// photos
     //public string Image { get; set; }
     //public ICollection<AppUserPhoto> AppUserPhotos { get; set; }
}