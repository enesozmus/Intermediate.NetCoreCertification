namespace Intermediate.MVC.Models;

public class SendMessageCommandRequest
{
     public int SendUserId { get; set; }
     public int ReceiveUserId { get; set; }
     public string Text { get; set; }
     public bool IsLooked { get; set; } = false;
}
