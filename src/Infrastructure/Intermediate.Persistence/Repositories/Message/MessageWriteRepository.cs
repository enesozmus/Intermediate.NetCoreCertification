using Intermediate.Application.IRepositories;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;

namespace Intermediate.Persistence.Repositories;

public class MessageWriteRepository : WriteRepository<Message>, IMessageWriteRepository
{
     public MessageWriteRepository(IntermediateContext context) : base(context) { }
}
