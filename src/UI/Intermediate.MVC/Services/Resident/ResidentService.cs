using Intermediate.MVC.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Intermediate.MVC.Services;

public class ResidentService : IResidentService
{
     private readonly IHttpContextAccessor _httpContextAccessor;
     private readonly IHttpClientFactory _httpClientFactory;

     public ResidentService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
     {
          _httpContextAccessor = httpContextAccessor;
          _httpClientFactory = httpClientFactory;
     }

     #region Site Sakinlerinin Sadece İsimlerini Getir

     public async Task<IReadOnlyList<GetResidentNamesQueryResponse>> GetResidentNamesAsync()
     {
          var client = CreateClient();
          var response = await client.GetAsync("http://localhost:5166/api/Residents/names");

          if (response.StatusCode == HttpStatusCode.NotFound)
               throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
          if (response.StatusCode == HttpStatusCode.Unauthorized)
               throw new ApplicationException($"Yetkili olmadığınız bir işlem yapmaya çalışıyorsunuz. Lütfen admin olarak giriş yapınız: {response.ReasonPhrase}");

          if (response.IsSuccessStatusCode)
          {
               var jsonString = await response.Content.ReadAsStringAsync();
               var listOfNames = System.Text.Json.JsonSerializer.Deserialize<IReadOnlyList<GetResidentNamesQueryResponse>>(jsonString, new JsonSerializerOptions
               {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
               });
               return listOfNames;
          }
          else
               return null;
     }

     #endregion

     #region Hepsini Getir

     public async Task<IReadOnlyList<GetResidentsQueryResponse>> GetResidentsAsync()
     {
          var client = CreateClient();

          var response = await client.GetAsync("http://localhost:5166/api/Residents");

          if (response.StatusCode == HttpStatusCode.NotFound)
               throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
          if (response.StatusCode == HttpStatusCode.Unauthorized)
               throw new ApplicationException($"Yetkili olmadığınız bir işlem yapmaya çalışıyorsunuz. Lütfen admin olarak giriş yapınız: {response.ReasonPhrase}");

          if (response.IsSuccessStatusCode)
          {
               var jsonString = await response.Content.ReadAsStringAsync();
               var listOfResidents = System.Text.Json.JsonSerializer.Deserialize<IReadOnlyList<GetResidentsQueryResponse>>(jsonString, new JsonSerializerOptions
               {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
               });
               return listOfResidents;
          }
          else
               return null;
     }

     #endregion

     #region Yeni Ekle

     public async Task<HttpResponseMessage> CreateResident(CreateResidentCommandRequest request)
     {
          var client = CreateClient();
          var jsonData = JsonConvert.SerializeObject(request);
          var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
          var response = await client.PostAsync("http://localhost:5166/api/Residents", content);
          if (response.StatusCode == HttpStatusCode.BadRequest)
               throw new ApplicationException($"Muhtemelen zaten kullanılan bir email ya da kullanıcı adı almaya çalışıyorsunuz!: {response.ReasonPhrase}");

          return response;
     }

     #endregion

     #region Güncelleme İçin Verileri Getir

     public async Task<UpdateResidentCommandRequest> GetViewForUpdateResident(int id)
     {
          var client = CreateClient();
          var response = await client.GetAsync($"http://localhost:5166/api/Residents/{id}");
          if (response.IsSuccessStatusCode)
          {
               var jsonData = await response.Content.ReadAsStringAsync();
               var data = JsonConvert.DeserializeObject<UpdateResidentCommandRequest>(jsonData);
               if (data == null)
                    throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
               return data;
          }
          throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
     }

     #region Güncelle

     public async Task<HttpResponseMessage> UpdateResident(UpdateResidentCommandRequest request)
     {
          var client = CreateClient();
          var jsonData = JsonConvert.SerializeObject(request);
          var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
          var response = await client.PutAsync("http://localhost:5166/api/Residents", content);
          return response;
     }

     #endregion

     #endregion

     #region Sil

     public async Task<HttpResponseMessage> RemoveResident(int id)
     {
          var client = CreateClient();
          var response = await client.DeleteAsync($"http://localhost:5166/api/Residents/{id}");
          if (response.IsSuccessStatusCode)
               return response;
          throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
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
