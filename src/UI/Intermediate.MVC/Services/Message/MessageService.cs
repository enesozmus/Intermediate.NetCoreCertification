using Intermediate.MVC.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Intermediate.MVC.Services;

public class MessageService : IMessageService
{
     private readonly IHttpContextAccessor _httpContextAccessor;
     private readonly IHttpClientFactory _httpClientFactory;

     public MessageService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
     {
          _httpContextAccessor = httpContextAccessor;
          _httpClientFactory = httpClientFactory;
     }

     #region Mesaj Gönder

     public async Task<HttpResponseMessage> CreateMessage(SendMessageCommandRequest request)
     {
          var client = CreateClient();
          var jsonData = JsonConvert.SerializeObject(request);
          var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
          var response = await client.PostAsync("http://localhost:5166/api/Messages", content);

          return response;
     }

     #endregion

     #region Gelen Mesajları Getir

     public async Task<IReadOnlyList<GetIncomingMessagesQueryResponse>> GetIncomingMessagesAsync()
     {
          var client = CreateClient();

          var response = await client.GetAsync("http://localhost:5166/api/Messages/incomingmessages");

          if (response.StatusCode == HttpStatusCode.NotFound)
               throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
          if (response.StatusCode == HttpStatusCode.Unauthorized)
               throw new ApplicationException($"Yetkili olmadığınız bir işlem yapmaya çalışıyorsunuz. Lütfen admin olarak giriş yapınız: {response.ReasonPhrase}");

          if (response.IsSuccessStatusCode)
          {
               var jsonString = await response.Content.ReadAsStringAsync();
               var listOfIncomingMessages = System.Text.Json.JsonSerializer.Deserialize<IReadOnlyList<GetIncomingMessagesQueryResponse>>(jsonString, new JsonSerializerOptions
               {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
               });
               return listOfIncomingMessages;
          }
          else
               return null;
     }

     #endregion

     #region Gönderilen Mesajları Getir

     public async Task<IReadOnlyList<GetSentMessagesQueryResponse>> GetSentMessagesAsync()
     {
          var client = CreateClient();

          var response = await client.GetAsync("http://localhost:5166/api/Messages/sentmessages");

          if (response.StatusCode == HttpStatusCode.NotFound)
               throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
          if (response.StatusCode == HttpStatusCode.Unauthorized)
               throw new ApplicationException($"Yetkili olmadığınız bir işlem yapmaya çalışıyorsunuz. Lütfen admin olarak giriş yapınız: {response.ReasonPhrase}");

          if (response.IsSuccessStatusCode)
          {
               var jsonString = await response.Content.ReadAsStringAsync();
               var listOfSentMessages = System.Text.Json.JsonSerializer.Deserialize<IReadOnlyList<GetSentMessagesQueryResponse>>(jsonString, new JsonSerializerOptions
               {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
               });
               return listOfSentMessages;
          }
          else
               return null;
     }

     #endregion

     #region Güncelleme İçin Verileri Getir

     public async Task<UpdateMessageCommandRequest> GetViewForUpdateMessage(int id)
     {
          var client = CreateClient();
          var response = await client.GetAsync($"http://localhost:5166/api/Messages/{id}");
          if (response.IsSuccessStatusCode)
          {
               var jsonData = await response.Content.ReadAsStringAsync();
               var data = JsonConvert.DeserializeObject<UpdateMessageCommandRequest>(jsonData);
               if (data == null)
                    throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
               return data;
          }
          throw new ApplicationException($"API çağrılırken bir şeyler ters gitti: {response.ReasonPhrase}");
     }

     #endregion

     #region Güncelle

     public async Task<HttpResponseMessage> UpdateMessage(UpdateMessageCommandRequest request)
     {
          var client = CreateClient();
          var jsonData = JsonConvert.SerializeObject(request);
          var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
          var response = await client.PutAsync("http://localhost:5166/api/Messages", content);
          return response;
     }

     #endregion

     #region Sil

     public async Task<HttpResponseMessage> RemoveMessage(int id)
     {
          var client = CreateClient();
          var response = await client.DeleteAsync($"http://localhost:5166/api/Messages/{id}");
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
