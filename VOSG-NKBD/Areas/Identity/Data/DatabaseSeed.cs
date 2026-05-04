using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VOSG_NKBD.Data;
using VOSG_NKBD.Models;
 
namespace VOSG_NKBD.Areas.Identity.Data
{
       public static class DatabaseSeed
       {
          public static async Task SeedDataAsync(IApplicationBuilder app)
          {
              using var scope = app.ApplicationServices.CreateScope();
  
              
              var context = scope.ServiceProvider.GetRequiredService<VOSG_NKBDDbContext>();
              var userManager = scope.ServiceProvider.GetRequiredService<UserManager<VOSG_NKBDUser>>();
  
              context.Database.EnsureCreated();
  
              
              if (context.Locations.Any()) return;
  
              var locations = new Location[]
              {
                  new () { LocationName = "Auckland Showgrounds",  Addresss = "217 Green Lane West",          Suburb = "Epsom",        City = "Auckland",   Country = "New Zealand", PostalCode = "1051",    PhoneNumber = "+6496230092"   },
                  new () { LocationName = "Nathan Phillips Square", Addresss = "100 Queen Street West",        Suburb = "Central City", City = "Toronto",    Country = "Canada",      PostalCode = "M5H2N2",  PhoneNumber = "+14163922489"  },
                  new () { LocationName = "Dr Phillips Center",    Addresss = "445 South Magnolia Avenue",    Suburb = "Central City", City = "Orlando",    Country = "USA",         PostalCode = "32801",   PhoneNumber = "+14073586603"  },
                  new () { LocationName = "Federation Square",     Addresss = "Swanston and Flinders Street", Suburb = "Central City", City = "Melbourne",  Country = "Australia",   PostalCode = "3000",    PhoneNumber = "+61396551900"  },
                  new () { LocationName = "Finlandia Hall",        Addresss = "Mannerheimintie 13",           Suburb = "Central City", City = "Helsinki",   Country = "Finland",     PostalCode = "00100",   PhoneNumber = "+35894024100"  },
              };
              context.Locations.AddRange(locations);
              await context.SaveChangesAsync();

              
              var places = new Place[]
              {
                  new() { PlaceName = "Main Hall A", Description = "Large event hall", Price = 500m, LocationsID = locations[0].LocationsID },
                  new() { PlaceName = "Conference B", Description = "Conference room", Price = 200m, LocationsID = locations[1].LocationsID },
                  new() { PlaceName = "Outdoor Stage", Description = "Open air stage", Price = 350m, LocationsID = locations[2].LocationsID },
                  new() { PlaceName = "Gallery Room", Description = "Art gallery space", Price = 150m, LocationsID = locations[3].LocationsID },
                  new() { PlaceName = "Concert Hall", Description = "Concert venue", Price = 800m, LocationsID = locations[4].LocationsID },
              };
              context.Places.AddRange(places);
              await context.SaveChangesAsync();

              
              var usersData = new (string First, string Last, string Email, string Phone)[]
              {
                  ("Nicolas", "Jackson",  "NicolasJackson@gmail.com", "+6402783218"   ),
                  ("Jenny",   "Monroe",   "JennyMonroe@gmail.com",    "+14161234567"  ),
                  ("Alice",   "Sydney",   "AliceSydney@gmail.com",    "+14071234567"  ),
                  ("Bobby",   "Gordon",   "BobbyGordon@gmail.com",    "+61412345678"  ),
                  ("Emma",    "Hathaway", "EmmaHathaway@gmail.com",   "+358411234567" ),
              };

              var createdUsers = new List<VOSG_NKBDUser>();
              foreach (var u in usersData)
          {
                      var existing = await userManager.FindByEmailAsync(u.Email);
                      if (existing == null)
              {
                      var user = new VOSG_NKBDUser
                      {
                          UserName = u.Email,
                          Email = u.Email,
                          FirstName = u.First,
                          LastName = u.Last,
                          Phone = u.Phone,
                          
                          EmailConfirmed = true}
                         
        ;
                      var result = await userManager.CreateAsync(user, "DefaultPassword456!");
                      if (result.Succeeded) createdUsers.Add(user);
                      }
                      else createdUsers.Add(existing);
              }

              if (createdUsers.Count < 5) return;

              
              var confirmations = new Confirmation[]
              {
                  new() { MemberId = createdUsers[1].Id, PlaceID = places[1].PlaceID, ConfirmationDate = DateTime.Today, StartTime = new DateTime(2026, 9, 14, 9, 0, 0), EndTime = new DateTime(2026, 9, 14, 10, 0, 0), TotalPrice = places[1].Price },
                  new() { MemberId = createdUsers[2].Id, PlaceID = places[2].PlaceID, ConfirmationDate = DateTime.Today, StartTime = new DateTime(2026, 9, 15, 9, 0, 0), EndTime = new DateTime(2026, 9, 15, 10, 0, 0), TotalPrice = places[2].Price },
                  new() { MemberId = createdUsers[3].Id, PlaceID = places[3].PlaceID, ConfirmationDate = DateTime.Today, StartTime = new DateTime(2026, 9, 16, 9, 0, 0), EndTime = new DateTime(2026, 9, 16, 10, 0, 0), TotalPrice = places[3].Price },
                  new() { MemberId = createdUsers[4].Id, PlaceID = places[4].PlaceID, ConfirmationDate = DateTime.Today, StartTime = new DateTime(2026, 9, 19, 9, 0, 0), EndTime = new DateTime(2026, 9, 19, 10, 0, 0), TotalPrice = places[4].Price },
              };
              context.Confirmations.AddRange(confirmations);
              await context.SaveChangesAsync();

              
              var payments = new Payment[]
              {
                 new() { ConfirmationID = confirmations[0].ConfirmationID, VOSG_NKBDId = confirmations[0].MemberId, PaymentAmount = confirmations[0].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
                 new() { ConfirmationID = confirmations[1].ConfirmationID, VOSG_NKBDId = confirmations[1].MemberId, PaymentAmount = confirmations[1].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
                 new() { ConfirmationID = confirmations[2].ConfirmationID, VOSG_NKBDId = confirmations[2].MemberId, PaymentAmount = confirmations[2].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
                 new() { ConfirmationID = confirmations[3].ConfirmationID, VOSG_NKBDId = confirmations[3].MemberId, PaymentAmount = confirmations[3].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
              };
             context.Payments.AddRange(payments);
             await context.SaveChangesAsync();
          }
       }
}