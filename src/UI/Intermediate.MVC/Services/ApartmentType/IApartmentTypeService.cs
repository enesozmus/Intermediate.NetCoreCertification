using Intermediate.MVC.Models;

namespace Intermediate.MVC.Services;

public interface IApartmentTypeService
{
     Task<IReadOnlyList<GetApartmentTypesQueryResponse>> GetApartmentTypesAsync();
     Task<HttpResponseMessage> CreateApartmentType(CreateApartmentTypeCommandRequest request);
     // Güncelleyeceğimiz entity'nin bilgilerini kolaylık sağlamak adına forma çekiyoruz.
     Task<UpdateApartmentTypeCommandRequest> GetViewForUpdateApartmentType(int id);
     Task<HttpResponseMessage> UpdateApartmentType(UpdateApartmentTypeCommandRequest request);
     Task<HttpResponseMessage> RemoveApartmentType(int id);
}
