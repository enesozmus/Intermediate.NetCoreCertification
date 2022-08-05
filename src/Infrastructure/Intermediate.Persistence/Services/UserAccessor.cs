using Intermediate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Intermediate.Persistence.Services;

public class UserAccessor : IUserAccessor
{
     private readonly IHttpContextAccessor _httpContextAccessor;
     public UserAccessor(IHttpContextAccessor httpContextAccessor)
     {
          _httpContextAccessor = httpContextAccessor;
     }

     public int GetUserId()
     {
          return Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
     }

     public string GetUsername()
     {
          return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
     }
}
