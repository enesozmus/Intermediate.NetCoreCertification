using Intermediate.Application.IRepositories;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;

namespace Intermediate.Persistence.Repositories;

public class BlockWriteRepository : WriteRepository<Block>, IBlockWriteRepository
{
     public BlockWriteRepository(IntermediateContext context) : base(context) { }
}
