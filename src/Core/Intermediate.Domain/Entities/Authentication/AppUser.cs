using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intermediate.Domain.Entities;

public class AppUser : IdentityUser<int>
{
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public string IdentityNumber { get; set; }
     public bool IsHirer { get; set; }
     public bool IsOwner { get; set; }
     public bool IsCarOwner { get; set; } = false;
     public string? CarPlate { get; set; }
     public ICollection<Apartment> Apartments { get; set; } = new HashSet<Apartment>();
     public ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
     public ICollection<AppUserPhoto> AppUserPhotos { get; set; } = new HashSet<AppUserPhoto>();

     [InverseProperty("SendUser")]
     public virtual ICollection<Message> SendedMessages { get; set; }
     [InverseProperty("ReceiveUser")]
     public virtual ICollection<Message> ReceivedMessages { get; set; }
}
