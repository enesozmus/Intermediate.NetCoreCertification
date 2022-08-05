using Intermediate.Application.IRepositories;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;

namespace Intermediate.Persistence.Repositories;

public class ApartmentTypeReadRepository : ReadRepository<ApartmentType>, IApartmentTypeReadRepository
{
     public ApartmentTypeReadRepository(IntermediateContext context) : base(context) { }
}
