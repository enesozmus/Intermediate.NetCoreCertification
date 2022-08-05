using Intermediate.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intermediate.Domain.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
     public void Configure(EntityTypeBuilder<AppUser> builder)
     {
          builder.Property(x => x.FirstName).IsRequired().HasMaxLength(15);
          builder.Property(x => x.LastName).IsRequired().HasMaxLength(15);
          builder.Property(x => x.IdentityNumber).IsRequired().HasMaxLength(11);
          builder.Property(x => x.UserName).IsRequired().HasMaxLength(15);
          builder.Property(x => x.Email).IsRequired().HasMaxLength(20);
          builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(13);

          #region ForeingKey

          builder.HasMany(x => x.SendedMessages)
                      .WithOne(x => x.SendUser)
                      .HasForeignKey(x => x.SendUserId)
                      .OnDelete(DeleteBehavior.Cascade);

          builder.HasMany(x => x.ReceivedMessages)
            .WithOne(x => x.ReceiveUser)
            .HasForeignKey(x => x.ReceiveUserId)
            .OnDelete(DeleteBehavior.NoAction);

          // => Kullanıcı silindiğinde kullanıcının fotoğrafları da silinmeli.
          builder.HasMany(x => x.AppUserPhotos)
               .WithOne(x => x.AppUser)
               .HasForeignKey(x => x.AppUserId)
               .OnDelete(DeleteBehavior.Cascade);

          // => Kullanıcı silindiğinde kullanıcının faturaları da silinmeli.
          builder.HasMany(x => x.Bills)
                 .WithOne(x => x.AppUser)
                 .HasForeignKey(x => x.AppUserId)
                 .OnDelete(DeleteBehavior.Cascade);

          // => Dairelerin silinmesi kısıtlandı.
          builder.HasMany(x => x.Apartments)
               .WithOne(x => x.AppUser)
               .HasForeignKey(x => x.AppUserId)
               .OnDelete(DeleteBehavior.Restrict);

          #endregion

          #region SeedData

          var hasher = new PasswordHasher<AppUser>();

          var user1 = new AppUser() { Id = 1, FirstName = "Enes", LastName = "Ozmus", Email = "enes@seeddata.com", EmailConfirmed = true, NormalizedEmail = " ENES@SEEDDATA.COM", UserName = "enesozmus",              IdentityNumber = "00000000001",    PhoneNumber = "0541 555 ####",     IsHirer = false,    IsOwner = true,  IsCarOwner = false,    NormalizedUserName = "ENESOZMUS", PasswordHash = hasher.HashPassword(null, "Customer1*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user2 = new AppUser() { Id = 2, FirstName = "Umay", LastName = "Zengin", Email = "umay@seeddata.com", EmailConfirmed = true, NormalizedEmail = "UMAY@SEEDDATA.COM", UserName = "umayzengin",             IdentityNumber = "00000000002",    PhoneNumber = "0542 555 ####",     IsHirer = true,     IsOwner = false, IsCarOwner = false,    NormalizedUserName = "UMAYZENGIN", PasswordHash = hasher.HashPassword(null, "Customer2*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user3 = new AppUser() { Id = 3, FirstName = "Selim", LastName = "Karaca", Email = "selim@seeddata.com", EmailConfirmed = true, NormalizedEmail = "SELIM@SEEDDATA.COM", UserName = "selimkaraca",         IdentityNumber = "00000000003",    PhoneNumber = "0543 555 ####",     IsHirer = true,     IsOwner = false, IsCarOwner = false,    NormalizedUserName = "SELIMKARACA", PasswordHash = hasher.HashPassword(null, "Customer3*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user4 = new AppUser() { Id = 4, FirstName = "Emine", LastName = "Yıldırım", Email = "emine@seeddata.com", EmailConfirmed = true, NormalizedEmail = "EMINE@SEEDDATA.COM", UserName = "emineyıldırım",     IdentityNumber = "00000000004",    PhoneNumber = "0544 555 ####",     IsHirer = true,     IsOwner = false, IsCarOwner = false,    NormalizedUserName = "EMINEYILDIRIM", PasswordHash = hasher.HashPassword(null, "Customer4*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user5 = new AppUser() { Id = 5, FirstName = "İhsan", LastName = "Yenilmez", Email = "ihsan@seeddata.com", EmailConfirmed = true, NormalizedEmail = "IHSAN@SEEDDATA.COM", UserName = "ihsanyenilmez",     IdentityNumber = "00000000005",    PhoneNumber = "0545 555 ####",     IsHirer = true,     IsOwner = false, IsCarOwner = false,    NormalizedUserName = "IHSANYENILMEZ", PasswordHash = hasher.HashPassword(null, "Customer5*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user6 = new AppUser() { Id = 6, FirstName = "Berrin", LastName = "Miral", Email = "berrin@seeddata.com", EmailConfirmed = true, NormalizedEmail = "BERRIN@SEEDDATA.COM", UserName = "berrinmiral",       IdentityNumber = "00000000006",    PhoneNumber = "0546 555 ####",     IsHirer = true,     IsOwner = false, IsCarOwner = false,    NormalizedUserName = "BERRINMIRAL", PasswordHash = hasher.HashPassword(null, "Customer6*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user7 = new AppUser() { Id = 7, FirstName = "Salih", LastName = "Yurdakul", Email = "salih@seeddata.com", EmailConfirmed = true, NormalizedEmail = "SALIH@SEEDDATA.COM", UserName = "salihyurdakul",     IdentityNumber = "00000000007",    PhoneNumber = "0547 555 ####",     IsHirer = true,     IsOwner = false, IsCarOwner = false,    NormalizedUserName = "SALIHYURDAKUL", PasswordHash = hasher.HashPassword(null, "Customer7*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user8 = new AppUser() { Id = 8, FirstName = "Zafer", LastName = "Kırat", Email = "zafer@seeddata.com", EmailConfirmed = true, NormalizedEmail = "ZAFER@SEEDDATA.COM", UserName = "zaferkırat",           IdentityNumber = "00000000008",    PhoneNumber = "0548 555 ####",     IsHirer = true,     IsOwner = false, IsCarOwner = false,    NormalizedUserName = "ZAFERKIRAT", PasswordHash = hasher.HashPassword(null, "Customer8*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user9 = new AppUser() { Id = 9, FirstName = "Emre", LastName = "Demir", Email = "emre@seeddata.com", EmailConfirmed = true, NormalizedEmail = "EMRE@SEEDDATA.COM", UserName = "emredemir",               IdentityNumber = "00000000009",    PhoneNumber = "0549 555 ####",     IsHirer = true,     IsOwner = false, IsCarOwner = false,    NormalizedUserName = "EMREDEMIR", PasswordHash = hasher.HashPassword(null, "Customer9*123"), SecurityStamp = Guid.NewGuid().ToString("D") };

          builder.HasData(user1, user2, user3, user4, user5, user6, user7, user8, user9);

          #endregion
     }
}
