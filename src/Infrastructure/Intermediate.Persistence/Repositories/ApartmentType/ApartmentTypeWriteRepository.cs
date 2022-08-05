using Intermediate.Application.IRepositories;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;

namespace Intermediate.Persistence.Repositories;

public class ApartmentTypeWriteRepository : WriteRepository<ApartmentType>, IApartmentTypeWriteRepository
{
     public ApartmentTypeWriteRepository(IntermediateContext context) : base(context) { }
}
