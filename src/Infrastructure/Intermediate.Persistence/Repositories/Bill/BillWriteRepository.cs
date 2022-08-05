using Intermediate.Application.IRepositories;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;

namespace Intermediate.Persistence.Repositories;

public class BillWriteRepository : WriteRepository<Bill>, IBillWriteRepository
{
     public BillWriteRepository(IntermediateContext context) : base(context) { }
}
