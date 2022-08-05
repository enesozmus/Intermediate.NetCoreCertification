namespace Intermediate.Domain.Entities;

public class BasePhoto : BaseEntity
{
     public string PhotoId { get; set; }
     public string Url { get; set; }
     public bool IsMain { get; set; }
}
