using Intermediate.Application.IRepositories;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;

namespace Intermediate.Persistence.Repositories;

public class MessageReadRepository : ReadRepository<Message>, IMessageReadRepository
{
     public MessageReadRepository(IntermediateContext context) : base(context) { }
}
