using CleanArquitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArquitecture.Infrastructure
{
   public class StreamerDbContext :DbContext
    {

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         //base.OnConfiguring(optionsBuilder);
         optionsBuilder.UseSqlServer("Data Source=L-SISTEM01;Database=CleanArquitecture;User Id=sa;Password=$y$t3m4z;");
      }

      public DbSet<Streamer> Streamer { get; set; }
      public DbSet<Video> Videos { get; set; }

   }
}
