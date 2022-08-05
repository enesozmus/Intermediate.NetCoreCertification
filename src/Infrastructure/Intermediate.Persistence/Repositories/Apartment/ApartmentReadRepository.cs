using Intermediate.Application.Features.ApartmentsOperations;
using Intermediate.Application.IRepositories;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Intermediate.Persistence.Repositories;

public class ApartmentReadRepository : ReadRepository<Apartment>, IApartmentReadRepository
{
     private readonly IntermediateContext _context;
     public ApartmentReadRepository(IntermediateContext context) : base(context)
     {
          _context = context;
     }

     public async Task<Apartment> GetApartment(int id)
     {
          return await _context.Apartments
               .Include(x => x.AppUser)
               .Include(x => x.Block)
               .Include(x => x.ApartmentType)
               .FirstOrDefaultAsync(x => x.Id == id) ?? new Apartment();
     }

     public async Task<IReadOnlyList<Apartment>> GetApartments()
     {
          return await _context.Apartments
               .Include(x => x.AppUser)
               .Include(x => x.Block)
               .Include(x => x.ApartmentType)
               .ToListAsync();
     }

     public async Task<IReadOnlyList<Apartment>> GetUserApartments(Expression<Func<Apartment, bool>> predicate)
     {
          return await _context.Apartments
               .Include(x => x.Block)
               .Include(x => x.ApartmentType)
               .Where(predicate)
               .ToListAsync();
     }
}
