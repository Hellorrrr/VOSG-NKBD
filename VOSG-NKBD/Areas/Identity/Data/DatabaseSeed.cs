using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using VOSG_NKBD.Areas.Identity.Data;
using VOSG_NKBD.Data;
using VOSG_NKBD.Models;

namespace VOSG_NKBD.Areas.Identity.Data
{
    public static class DatabaseSeed
    {
        public static async Task SeedDataAsync(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context            = serviceScope.ServiceProvider.GetRequiredService<VOSG_NKBDDbContext>();
            var userManager        = serviceScope.ServiceProvider.GetRequiredService<UserManager<VOSG_NKBDUser>>();

            // Ensure database is created
            context.Database.EnsureCreated();

            // Prevent duplicate seeding
            if (context.Locations.Any() || context.Bookings.Any() || context.Courts.Any() || context.Equipments.Any() || context.Payments.Any())
            {
                return;
            }

            // Seed Locations 
            var locations = new Location[]
            {
                new Location { LocationName = "Auckland Showgrounds",                        Addresss = "217 Green Lane West",               Suburb = "Epsom",        City = "Auckland",  Country = "New Zealand", PostalCode = "1051",     PhoneNumber = "+64 9-623-0092" },
                new Location { LocationName = "Nathan Phillips Square",                      Addresss = "100 Queen Street West",             Suburb = "Central City", City = "Toronto",   Country = "Canada",      PostalCode = "M5H 2N2",  PhoneNumber = "+1 416-392-2489" },
                new Location { LocationName = "Dr. Phillips Center for the Performing Arts", Addresss = "445 South Magnolia Avenue",         Suburb = "Central City", City = "Orlando",   Country = "The USA",     PostalCode = "FL 32801", PhoneNumber = "+1 407-358-6603" },
                new Location { LocationName = "Federation Square",                           Addresss = "Swanston Street & Flinders Street", Suburb = "Central City", City = "Melbourne", Country = "Australia",   PostalCode = "VIC 3000", PhoneNumber = "+61 3 9655 1900" },
                new Location { LocationName = "Finlandia Hall",                              Addresss = "Mannerheimintie 13",                Suburb = "Central City", City = "Helsinki",  Country = "Finland",     PostalCode = "00100",    PhoneNumber = "+358 9 40241" }
            };
            context.Locations.AddRange(locations);
            await context.SaveChangesAsync();

            // Seed Users via UserManager
            var usersToCreate = new (string FirstName, string LastName, string Email, string Phone)[]
            {
                ("Nicolas", "Jackson",  "NicolasJackson@gmail.com", "+64-02-783-21892"),
                ("Jenny",   "Monroe",   "JennyMonroe@gmail.com",    "+1-416-123-4567"),
                ("Alice",   "Sydney",   "AliceSydney@gmail.com",    "+1-407-123-4567"),
                ("Bobby",   "Gordon",   "BobbyGordon@gmail.com",    "+61-412-345-678"),
                ("Emma",    "Hathaway", "EmmaHathaway@gmail.com",   "+358-41-123-4567")
            };

            var createdUsers = new List<VOSG_NKBDUser>();

            foreach (var u in usersToCreate)
            {
                var existingUser = await userManager.FindByEmailAsync(u.Email);
                if (existingUser == null)
                {
                    var user = new VOSG_NKBDUser
                    {
                        UserName  = u.Email,
                        Email     = u.Email,
                        FirstName = u.FirstName,
                        LastName  = u.LastName,
                        Phone     = u.Phone
                    };
                    var result = await userManager.CreateAsync(user, "DefaultPassword456!");
                    if (result.Succeeded)
                    {
                        createdUsers.Add(user);
                    }
                }
                else
                {
                    createdUsers.Add(existingUser);
                }
            }

            var bookings = new Booking[]
            {
                new Confirmation
                {
                    MemberId         = createdUsers[1].Id,
                    PlaceID          = place[1].PlaceID,
                    ConfirmationDate = new DateTime(2026, 9, 10),
                    StartTime        = new DateTime(2026, 9, 14, 9, 0, 0),
                    EndTime          = new DateTime(2026, 9, 13, 10, 0, 0),
                    TotalPrice       = place[1].Price
                },
                new Confirmation
                {
                    MemberId         = createdUsers[2].Id,
                    PlaceID          = place[2].PlaceID,
                    ConfirmationDate = new DateTime(2026, 9, 10),
                    StartTime        = new DateTime(2026, 9, 15, 9, 0, 0),
                    EndTime          = new DateTime(2026, 9, 16, 10, 0, 0),
                    TotalPrice       = place[2].Price
                },
                new Confirmation
                {
                    MemberId         = createdUsers[3].Id,
                    PlaceID          = place[3].PlaceID,
                    ConfirmationDate = new DateTime(2026, 9, 10),
                    StartTime        = new DateTime(2026, 9, 16, 9, 0, 0),
                    EndTime          = new DateTime(2026, 9, 17, 10, 0, 0),
                    TotalPrice       = place[3].Price
                },
                new Confirmation
                {
                    MemberId         = createdUsers[4].Id,
                    PlaceID          = place[4].PlaceID,
                    ConfirmationDate = new DateTime(2026, 9, 10),
                    StartTime        = new DateTime(2026, 9, 19, 9, 0, 0),
                    EndTime          = new DateTime(2026, 9, 18, 10, 0, 0),
                    TotalPrice       = place[4].Price
                },
            };
            object confirmation = context.Confirmation;
            await context.SaveChangesAsync();

            // Seed Payments
            var payments = new Payment[]
            {
                new(){ Confirmation[0].VOSG_NKBDId, PaymentAmount = confirmation[0].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
                new Payment { VOSG_NKBDId = confirmation[1].MemberId, PaymentAmount = confirmation[1].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
                new Payment { VOSG_NKBDId = confirmation[2].MemberId, PaymentAmount = confirmation[2].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
                new Payment { VOSG_NKBDId = confirmation[3].MemberId, PaymentAmount = confirmation[3].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
                new Payment { VOSG_NKBDId = confirmation[4].MemberId, PaymentAmount = confirmation[4].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" }
            };
            context.Payments.AddRange(payments);
            await context.SaveChangesAsync();
        }
    }
}