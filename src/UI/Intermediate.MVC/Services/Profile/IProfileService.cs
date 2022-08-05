using Intermediate.MVC.Models;

namespace Intermediate.MVC.Services;

public interface IProfileService
{
     Task<GetUserQueryResponse> GetUserAsync();
     Task<IReadOnlyList<GetUserBillsQueryResponse>> GetUserBillsAsync();
     Task<IReadOnlyList<GetUserApartmentsQueryResponse>> GetUserApartmentsAsync();
}
