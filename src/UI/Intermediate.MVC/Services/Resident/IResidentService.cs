using Intermediate.MVC.Models;

namespace Intermediate.MVC.Services;

public interface IResidentService
{
     Task<IReadOnlyList<GetResidentsQueryResponse>> GetResidentsAsync();
     Task<IReadOnlyList<GetResidentNamesQueryResponse>> GetResidentNamesAsync();
     Task<HttpResponseMessage> CreateResident(CreateResidentCommandRequest request);
     // Güncelleyeceğimiz entity'nin bilgilerini kolaylık sağlamak adına forma çekiyoruz.
     Task<UpdateResidentCommandRequest> GetViewForUpdateResident(int id);
     Task<HttpResponseMessage> UpdateResident(UpdateResidentCommandRequest request);
     Task<HttpResponseMessage> RemoveResident(int id);
}
