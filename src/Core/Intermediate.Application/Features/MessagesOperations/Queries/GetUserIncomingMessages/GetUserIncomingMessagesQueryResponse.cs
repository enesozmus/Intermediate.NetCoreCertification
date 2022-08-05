namespace Intermediate.Application.Features.MessagesOperations;

public class GetIncomingMessagesQueryResponse
{
     public int Id { get; set; }
     public int SendUserId { get; set; }
     public int ReceiveUserId { get; set; }
     public string Text { get; set; }
     public bool IsLooked { get; set; }
     public DateTime CreatedDate { get; set; }
}