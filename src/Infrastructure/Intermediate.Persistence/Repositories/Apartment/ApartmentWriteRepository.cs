using Intermediate.Application.IRepositories;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;

namespace Intermediate.Persistence.Repositories;

public class ApartmentWriteRepository : WriteRepository<Apartment>, IApartmentWriteRepository
{
     public ApartmentWriteRepository(IntermediateContext context) : base(context) { }
}
