using Intermediate.MVC.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Intermediate.MVC.Services;

public class BillService : IBillService
{
     private readonly IHttpContextAccessor _httpContextAccessor;
     private readonly IHttpClientFactory _httpClientFactory;

     public BillService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
     {
          _httpContextAccessor = httpContextAccessor;
          _httpClientFactory = httpClientFactory;
     }

     #region Hepsini Getir

     public async Task<IReadOnlyList<GetBillsQueryResponse>> GetBillsAsync()
     {
          var client = CreateClient();

          var response = await client.GetAsync("http://localhost:5166/api/Bills");

          if (response.StatusCode == HttpStatusCode.NotFound)
               throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
          if (response.StatusCode == HttpStatusCode.Unauthorized)
               throw new ApplicationException($"Yetkili olmadığınız bir işlem yapmaya çalışıyorsunuz. Lütfen admin olarak giriş yapınız: {response.ReasonPhrase}");

          if (response.IsSuccessStatusCode)
          {
               var jsonString = await response.Content.ReadAsStringAsync();
               var listOfBills = System.Text.Json.JsonSerializer.Deserialize<IReadOnlyList<GetBillsQueryResponse>>(jsonString, new JsonSerializerOptions
               {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
               });
               return listOfBills;
          }
          else
               return null;
     }

     #endregion

     #region Yeni Ekle

     public async Task<HttpResponseMessage> CreateBill(CreateBillCommandRequest request)
     {
          var client = CreateClient();
          var jsonData = JsonConvert.SerializeObject(request);
          var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
          var response = await client.PostAsync("http://localhost:5166/api/Bills", content);

          return response;
     }

     #endregion

     #region Güncelleme İçin Verileri Getir

     public async Task<UpdateBillCommandRequest> GetViewForUpdateBill(int id)
     {
          var client = CreateClient();
          var response = await client.GetAsync($"http://localhost:5166/api/Bills/{id}");
          if (response.IsSuccessStatusCode)
          {
               var jsonData = await response.Content.ReadAsStringAsync();
               var data = JsonConvert.DeserializeObject<UpdateBillCommandRequest>(jsonData);
               if (data == null)
                    throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
               return data;
          }
          throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
     }

     #region Güncelle

     public async Task<HttpResponseMessage> UpdateBill(UpdateBillCommandRequest request)
     {
          var client = CreateClient();
          var jsonData = JsonConvert.SerializeObject(request);
          var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
          var response = await client.PutAsync("http://localhost:5166/api/Bills", content);
          return response;
     }

     #endregion

     #endregion

     #region Sil

     public async Task<HttpResponseMessage> RemoveBill(int id)
     {
          var client = CreateClient();
          var response = await client.DeleteAsync($"http://localhost:5166/api/Bills/{id}");
          if (response.IsSuccessStatusCode)
               return response;
          throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
     }

     #endregion

     #region Ödeme Yap

     public async Task<HttpResponseMessage> IsPaid(int id)
     {
          var client = CreateClient();
          var jsonData = JsonConvert.SerializeObject(id);
          var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
          var response = await client.PutAsync($"http://localhost:5166/api/Bills/{id}", content);
          return response;
     }

     #endregion

     #region Token Değerine "Bearer" ifadesini ekliyoruz

     private HttpClient CreateClient()
     {
          var client = _httpClientFactory.CreateClient();
          var token = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
          if (token != null)
               client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
          return client;
     }

     #endregion
}
