using Intermediate.MVC.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Intermediate.MVC.Services;

public class ProfileService : IProfileService
{
     private readonly IHttpContextAccessor _httpContextAccessor;
     private readonly IHttpClientFactory _httpClientFactory;

     public ProfileService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
     {
          _httpContextAccessor = httpContextAccessor;
          _httpClientFactory = httpClientFactory;
     }

     #region Profil Bilgilerini Getir

     public async Task<GetUserQueryResponse> GetUserAsync()
     {
          var client = CreateClient();
          var response = await client.GetAsync("http://localhost:5166/api/Profiles");

          if (response.StatusCode == HttpStatusCode.NotFound)
               throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
          if (response.StatusCode == HttpStatusCode.Unauthorized)
               throw new ApplicationException($"Yetkili olmadığınız bir işlem yapmaya çalışıyorsunuz. Lütfen admin olarak giriş yapınız: {response.ReasonPhrase}");

          if (response.IsSuccessStatusCode)
          {
               var jsonString = await response.Content.ReadAsStringAsync();
               var profile = System.Text.Json.JsonSerializer.Deserialize<GetUserQueryResponse>(jsonString, new JsonSerializerOptions
               {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
               });
               return profile;
          }
          else
               return null;
     }

     #endregion

     #region Kullanıcıya Ait Faturaları Getir

     public async Task<IReadOnlyList<GetUserBillsQueryResponse>> GetUserBillsAsync()
     {
          var client = CreateClient();
          var response = await client.GetAsync("http://localhost:5166/api/Profiles/userbills");

          if (response.StatusCode == HttpStatusCode.NotFound)
               throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
          if (response.StatusCode == HttpStatusCode.Unauthorized)
               throw new ApplicationException($"Yetkili olmadığınız bir işlem yapmaya çalışıyorsunuz. Lütfen admin olarak giriş yapınız: {response.ReasonPhrase}");

          if (response.IsSuccessStatusCode)
          {
               var jsonString = await response.Content.ReadAsStringAsync();
               var userBills = System.Text.Json.JsonSerializer.Deserialize<IReadOnlyList<GetUserBillsQueryResponse>>(jsonString, new JsonSerializerOptions
               {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
               });
               return userBills;
          }
          else
               return null;
     }

     #endregion

     #region Kullanıcıya Ait Daireleri Getir

     public async Task<IReadOnlyList<GetUserApartmentsQueryResponse>> GetUserApartmentsAsync()
     {
          var client = CreateClient();
          var response = await client.GetAsync("http://localhost:5166/api/Profiles/userapartments");

          if (response.StatusCode == HttpStatusCode.NotFound)
               throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
          if (response.StatusCode == HttpStatusCode.Unauthorized)
               throw new ApplicationException($"Yetkili olmadığınız bir işlem yapmaya çalışıyorsunuz. Lütfen admin olarak giriş yapınız: {response.ReasonPhrase}");

          if (response.IsSuccessStatusCode)
          {
               var jsonString = await response.Content.ReadAsStringAsync();
               var userApartments = System.Text.Json.JsonSerializer.Deserialize< IReadOnlyList<GetUserApartmentsQueryResponse>>(jsonString, new JsonSerializerOptions
               {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
               });
               return userApartments;
          }
          else
               return null;
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
