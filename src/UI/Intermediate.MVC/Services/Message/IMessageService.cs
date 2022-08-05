using Intermediate.MVC.Models;

namespace Intermediate.MVC.Services;

public interface IMessageService
{
     Task<IReadOnlyList<GetSentMessagesQueryResponse>> GetSentMessagesAsync();
     Task<IReadOnlyList<GetIncomingMessagesQueryResponse>> GetIncomingMessagesAsync();
     Task<HttpResponseMessage> CreateMessage(SendMessageCommandRequest request);
     // Güncelleyeceğimiz entity'nin bilgilerini kolaylık sağlamak adına forma çekiyoruz.
     Task<UpdateMessageCommandRequest> GetViewForUpdateMessage(int id);
     Task<HttpResponseMessage> UpdateMessage(UpdateMessageCommandRequest request);
     Task<HttpResponseMessage> RemoveMessage(int id);
}
