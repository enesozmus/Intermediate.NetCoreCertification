namespace Intermediate.Domain.Entities;

public class AppUserPhoto : BasePhoto
{
     public string PhotoId { get; set; }
     public string Url { get; set; }
     public bool IsMain { get; set; }
     public int AppUserId { get; set; }
     public AppUser AppUser { get; set; }
}
