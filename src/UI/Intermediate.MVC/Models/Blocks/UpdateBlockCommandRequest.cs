namespace Intermediate.MVC.Models;

public class UpdateBlockCommandRequest
{
     public int Id { get; set; }
     public string BlockName { get; set; }
     public string Address { get; set; }
     public int TotalFlats { get; set; }
     public int TotalFloors { get; set; }
}
