using Intermediate.MVC.Models;

namespace Intermediate.MVC.Services;

public interface IBillService
{
     Task<IReadOnlyList<GetBillsQueryResponse>> GetBillsAsync();
     Task<HttpResponseMessage> CreateBill(CreateBillCommandRequest request);
     // Güncelleyeceğimiz entity'nin bilgilerini kolaylık sağlamak adına forma çekiyoruz.
     Task<UpdateBillCommandRequest> GetViewForUpdateBill(int id);
     Task<HttpResponseMessage> UpdateBill(UpdateBillCommandRequest request);
     Task<HttpResponseMessage> RemoveBill(int id);
     Task<HttpResponseMessage> IsPaid(int id);
}
