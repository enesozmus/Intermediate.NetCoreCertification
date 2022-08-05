using System.ComponentModel.DataAnnotations.Schema;

namespace Intermediate.Domain.Entities;

public class Message : BaseEntity
{
     public int SendUserId { get; set; }
     public int ReceiveUserId { get; set; }
     public string Text { get; set; }
     public bool IsLooked { get; set; } = false;

     //[ForeignKey("SendUserId")]
     public virtual AppUser SendUser { get; set; }

     //[ForeignKey("ReceiveUserId")]
     public virtual AppUser ReceiveUser { get; set; }
}
