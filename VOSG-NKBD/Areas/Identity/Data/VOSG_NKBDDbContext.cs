using Microsoft.EntityFrameworkCore;
using VOSG_NKBD.Models;
 
namespace VOSG_NKBD.Data
{

       public class VOSG_NKBDDbContext : DbContext
       {
          public VOSG_NKBDDbContext(DbContextOptions<VOSG_NKBDDbContext> options)
              : base(options) { }
  
          public DbSet<Location> Locations { get; set; } = default!;
          public DbSet<Place> Places { get; set; } = default!;
          public DbSet<Confirmation> Confirmations { get; set; } = default!;
          public DbSet<Payment> Payments { get; set; } = default!;
          public DbSet<Activities> Activities { get; set; } = default!;
  
          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
              base.OnModelCreating(modelBuilder);
          }
       }
}