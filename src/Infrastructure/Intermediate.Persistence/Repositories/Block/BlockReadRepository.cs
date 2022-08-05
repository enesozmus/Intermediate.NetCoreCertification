using Intermediate.Application.IRepositories;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;

namespace Intermediate.Persistence.Repositories;

public class BlockReadRepository : ReadRepository<Block>, IBlockReadRepository
{
     public BlockReadRepository(IntermediateContext context) : base(context) { }
}
