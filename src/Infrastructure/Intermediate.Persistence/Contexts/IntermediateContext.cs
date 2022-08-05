using Intermediate.Domain.Configurations;
using Intermediate.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Intermediate.Persistence.Contexts;

public class IntermediateContext : IdentityDbContext<AppUser, AppRole, int>
{
     public IntermediateContext(DbContextOptions<IntermediateContext> options) : base(options) { }

     #region Entities

     public DbSet<Block> Blocks { get; set; }
     public DbSet<ApartmentType> ApartmentTypes { get; set; }
     public DbSet<ApartmentPhoto> ApartmentPhotos { get; set; }
     public DbSet<Apartment> Apartments { get; set; }
     public DbSet<Bill> Bills { get; set; }
     public DbSet<Message> Messages { get; set; }
     public DbSet<AppUserPhoto> AppUserPhotos { get; set; }


     #endregion


     #region Customized SaveChangesAsync

     public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
     {
          foreach (var entry in ChangeTracker.Entries<BaseEntity>())
          {
               switch (entry.State)
               {
                    case EntityState.Added:
                         entry.Entity.CreatedDate = DateTime.Now;

                         break;
                    case EntityState.Modified:
                         entry.Entity.LastModifiedDate = DateTime.Now;
                         break;
               }
          }
          return base.SaveChangesAsync(cancellationToken);
     }

     #endregion


     #region OnModelCreating

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          this.SeedUserRoles(modelBuilder);

          modelBuilder.Entity<AppUser>().HasIndex(u => u.IdentityNumber).IsUnique();
          modelBuilder.Entity<AppUser>().HasIndex(u => u.Email).IsUnique();
          modelBuilder.Entity<AppUser>().HasIndex(u => u.PhoneNumber).IsUnique(); ;

          modelBuilder.ApplyConfiguration(new AppUserConfiguration());
          modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
          modelBuilder.ApplyConfiguration(new BlockConfiguration());
          modelBuilder.ApplyConfiguration(new ApartmentTypeConfiguration());
          modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
          modelBuilder.ApplyConfiguration(new BillConfiguration());
          modelBuilder.ApplyConfiguration(new MessageConfiguration());

          base.OnModelCreating(modelBuilder);
     }

     private void SeedUserRoles(ModelBuilder builder)
     {
          builder.Entity<IdentityUserRole<int>>()
               .HasData(
               new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
               new IdentityUserRole<int>() { RoleId = 2, UserId = 2 },
               new IdentityUserRole<int>() { RoleId = 2, UserId = 3 },
               new IdentityUserRole<int>() { RoleId = 2, UserId = 4 },
               new IdentityUserRole<int>() { RoleId = 2, UserId = 5 },
               new IdentityUserRole<int>() { RoleId = 2, UserId = 6 },
               new IdentityUserRole<int>() { RoleId = 2, UserId = 7 },
               new IdentityUserRole<int>() { RoleId = 2, UserId = 8 },
               new IdentityUserRole<int>() { RoleId = 2, UserId = 9 });
     }

     #endregion
}
