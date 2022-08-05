namespace Intermediate.MVC.Models;

public class UpdateMessageCommandRequest
{
     public int Id { get; set; }
     public string Text { get; set; }
     public bool IsLooked { get; set; } = false;
}
