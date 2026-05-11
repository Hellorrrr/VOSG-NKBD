using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VOSG_NKBD.Data;
using VOSG_NKBD.Models;
using VOSG_NKBD.Areas.Identity.Data;
 
   var builder = WebApplication.CreateBuilder(args);

   var connectionString = builder.Configuration.GetConnectionString("VOSG_NKBDContextConnection")
      ?? throw new InvalidOperationException("Connection string 'VOSG_NKBDContextConnection' not found.");

  builder.Services.AddDbContext<VOSG_NKBDContext>(options =>
      options.UseSqlServer(connectionString));

  builder.Services.AddDbContext<VOSG_NKBDDbContext>(options =>
      options.UseSqlServer(connectionString));

  builder.Services.AddDefaultIdentity<VOSG_NKBDUser>(options =>
      options.SignIn.RequireConfirmedAccount = false)
.AddEntityFrameworkStores<VOSG_NKBDContext>();

  builder.Services.AddControllersWithViews();

  var app = builder.Build();

  if (!app.Environment.IsDevelopment())
  {
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
  }

  app.UseHttpsRedirection();

  app.UseStaticFiles();
  app.UseRouting();

  app.UseAuthentication();
  app.UseAuthorization();

  app.MapRazorPages();
  app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");

  await DatabaseSeed.SeedDataAsync(app);

  app.Run();