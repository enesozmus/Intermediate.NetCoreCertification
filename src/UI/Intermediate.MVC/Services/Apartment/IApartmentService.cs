using Intermediate.MVC.Models;

namespace Intermediate.MVC.Services;

public interface IApartmentService
{
     Task<IReadOnlyList<GetApartmentsQueryResponse>> GetApartmentsAsync();
     Task<HttpResponseMessage> CreateApartment(CreateApartmentCommandRequest request);
     // Güncelleyeceğimiz entity'nin bilgilerini kolaylık sağlamak adına forma çekiyoruz.
     Task<UpdateApartmentCommandRequest> GetViewForUpdateApartment(int id);
     Task<HttpResponseMessage> UpdateApartment(UpdateApartmentCommandRequest request);
     Task<HttpResponseMessage> RemoveApartment(int id);
}
