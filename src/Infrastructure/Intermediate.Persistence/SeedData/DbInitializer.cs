using Intermediate.Domain.Entities;
using Intermediate.Domain.Enums;
using Intermediate.Persistence.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Intermediate.Persistence.SeedData;

public class DbInitializer
{
     public static void Initialize(IApplicationBuilder applicationBuilder)
     {
          using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
          {
               var context = serviceScope.ServiceProvider.GetService<IntermediateContext>();
               context.Database.Migrate();

               #region Blocks

               if (!context.Blocks.Any())
               {
                    context.Blocks.AddRange(new List<Block>()
                    {
                         new Block {BlockName = "A Blok", Address = "Adres | SeedData", TotalFlats = 47, TotalFloors = 188, CreatedDate = new DateTime(2022, 07, 26) },
                         new Block {BlockName = "B Blok", Address = "Adres | SeedData", TotalFlats = 47, TotalFloors = 188, CreatedDate = new DateTime(2022, 07, 26) },
                         new Block {BlockName = "C Blok", Address = "Adres | SeedData", TotalFlats = 47, TotalFloors = 188, CreatedDate = new DateTime(2022, 07, 26) },
                         new Block {BlockName = "D Blok", Address = "Adres | SeedData", TotalFlats = 47, TotalFloors = 188, CreatedDate = new DateTime(2022, 07, 26) },
                         new Block {BlockName = "E Blok", Address = "Adres | SeedData", TotalFlats = 47, TotalFloors = 188, CreatedDate = new DateTime(2022, 07, 26) },
                    });
                    context.SaveChanges();
               }

               #endregion

               #region ApartmentTypes

               if (!context.ApartmentTypes.Any())
               {
                    context.ApartmentTypes.AddRange(new List<ApartmentType>()
                    {
                         new ApartmentType {Type = "0+1", CreatedDate = new DateTime(2022, 07, 26) },
                         new ApartmentType {Type = "1+1", CreatedDate = new DateTime(2022, 07, 26) },
                         new ApartmentType {Type = "2+1", CreatedDate = new DateTime(2022, 07, 26) },
                         new ApartmentType {Type = "3+1", CreatedDate = new DateTime(2022, 07, 26) },
                         new ApartmentType {Type = "4+1", CreatedDate = new DateTime(2022, 07, 26) },
                    });
                    context.SaveChanges();
               }

               #endregion

               #region Apartment

               if (!context.Apartments.Any())
               {
                    context.Apartments.AddRange(new List<Apartment>()
                    {
                         new Apartment { Floor = 1, DoorNumber = 1, IsAvailable = false,  AppUserId = 1, BlockId = 1, ApartmentTypeId = 3, CreatedDate = new DateTime(2022, 07, 26) },
                         new Apartment { Floor = 1, DoorNumber = 2, IsAvailable = false,  AppUserId = 2, BlockId = 1, ApartmentTypeId = 3, CreatedDate = new DateTime(2022, 07, 26) },
                         new Apartment { Floor = 1, DoorNumber = 3, IsAvailable = false,  AppUserId = 3, BlockId = 1, ApartmentTypeId = 3, CreatedDate = new DateTime(2022, 07, 26) },
                         new Apartment { Floor = 1, DoorNumber = 4, IsAvailable = false,  AppUserId = 4, BlockId = 1, ApartmentTypeId = 3, CreatedDate = new DateTime(2022, 07, 26) },
                         new Apartment { Floor = 2, DoorNumber = 5, IsAvailable = false,  AppUserId = 5, BlockId = 1, ApartmentTypeId = 3, CreatedDate = new DateTime(2022, 07, 26) },
                         new Apartment { Floor = 2, DoorNumber = 6, IsAvailable = false,  AppUserId = 6, BlockId = 1, ApartmentTypeId = 3, CreatedDate = new DateTime(2022, 07, 26) },
                         new Apartment { Floor = 2, DoorNumber = 7, IsAvailable = false,  AppUserId = 7, BlockId = 1, ApartmentTypeId = 3, CreatedDate = new DateTime(2022, 07, 26) },
                         new Apartment { Floor = 2, DoorNumber = 8, IsAvailable = false,  AppUserId = 8, BlockId = 1, ApartmentTypeId = 3, CreatedDate = new DateTime(2022, 07, 26) },
                         new Apartment { Floor = 3, DoorNumber = 9, IsAvailable = false,  AppUserId = 9, BlockId = 1, ApartmentTypeId = 3, CreatedDate = new DateTime(2022, 07, 26) }
                    });
                    context.SaveChanges();
               }

               #endregion

               #region Bill

               if (!context.Bills.Any())
               {
                    context.Bills.AddRange(new List<Bill>()
                    {
                         new Bill { AppUserId = 1, WhichMonth = WhichMonth.Agustos, BillType = BillType.Aidat, AmountPayable = 150, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 2, WhichMonth = WhichMonth.Agustos, BillType = BillType.Aidat, AmountPayable = 150, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 3, WhichMonth = WhichMonth.Agustos, BillType = BillType.Aidat, AmountPayable = 150, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 4, WhichMonth = WhichMonth.Agustos, BillType = BillType.Aidat, AmountPayable = 150, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 1, WhichMonth = WhichMonth.Agustos, BillType = BillType.Elektrik, AmountPayable = 430, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 2, WhichMonth = WhichMonth.Agustos, BillType = BillType.Elektrik, AmountPayable = 470, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 3, WhichMonth = WhichMonth.Agustos, BillType = BillType.Elektrik, AmountPayable = 390, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 4, WhichMonth = WhichMonth.Agustos, BillType = BillType.Elektrik, AmountPayable = 410, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 1, WhichMonth = WhichMonth.Agustos, BillType = BillType.Su, AmountPayable = 120, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 2, WhichMonth = WhichMonth.Agustos, BillType = BillType.Su, AmountPayable = 130, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 3, WhichMonth = WhichMonth.Agustos, BillType = BillType.Su, AmountPayable = 170, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 4, WhichMonth = WhichMonth.Agustos, BillType = BillType.Su, AmountPayable = 90, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 1, WhichMonth = WhichMonth.Agustos, BillType = BillType.Dogalgaz, AmountPayable = 80, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 2, WhichMonth = WhichMonth.Agustos, BillType = BillType.Dogalgaz, AmountPayable = 90, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 3, WhichMonth = WhichMonth.Agustos, BillType = BillType.Internet, AmountPayable = 110, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) },
                         new Bill { AppUserId = 4, WhichMonth = WhichMonth.Agustos, BillType = BillType.Internet, AmountPayable = 130, IsPaid = false, DeadlineDate = DateTime.Now, CreatedDate = new DateTime(2022, 07, 26) }
                    });
                    context.SaveChanges();
               }

               #endregion

               #region Messages

               if (!context.Messages.Any())
               {
                    context.Messages.AddRange(new List<Message>()
                    {
                         new Message { SendUserId = 1, ReceiveUserId = 2, Text = "SeedData | Kullanıcı 1'den Kullanıcı 2'ye Mesaj", IsLooked = false, CreatedDate = new DateTime(2022, 07, 26) },
                         new Message { SendUserId = 1, ReceiveUserId = 3, Text = "SeedData | Kullanıcı 1'den Kullanıcı 3'e Mesaj", IsLooked = false, CreatedDate = new DateTime(2022, 07, 26) },
                         new Message { SendUserId = 2, ReceiveUserId = 5, Text = "SeedData | Kullanıcı 2'den Kullanıcı 5'e Mesaj", IsLooked = false, CreatedDate = new DateTime(2022, 07, 26) },
                    });
                    context.SaveChanges();
               }

               #endregion
          }
     }
}
