namespace Intermediate.Application.Features.ResidentsOperations;

public class GetResidentDetailQueryResponse
{
     public int Id { get; set; }
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
}
