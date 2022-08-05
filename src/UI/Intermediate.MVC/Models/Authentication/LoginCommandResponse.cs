namespace Intermediate.MVC.Models;

public class LoginCommandResponse
{
     public string UserName { get; set; }
     public string Token { get; set; }
     public bool IsSuccess { get; set; }
}
