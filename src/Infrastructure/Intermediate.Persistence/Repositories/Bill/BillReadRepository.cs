using Intermediate.Application.IRepositories;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Intermediate.Persistence.Repositories;

public class BillReadRepository : ReadRepository<Bill>, IBillReadRepository
{
     private readonly IntermediateContext _context;
     public BillReadRepository(IntermediateContext context) : base(context)
     {
          _context = context;
     }

     public async Task<Bill> GetBill(int id)
     {
          return await _context.Bills
               .Include(x => x.AppUser)
               .FirstOrDefaultAsync(x => x.Id == id) ?? new Bill();
     }

     public async Task<IReadOnlyList<Bill>> GetBills()
     {
          return await _context.Bills
               .Include(x => x.AppUser)
               .ToListAsync();
     }
}
