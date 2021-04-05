using Microsoft.EntityFrameworkCore;

namespace StatisticsUniqWordsHttp
{
    public class AppContext : DbContext
    {
        public DbSet<RequestStats> RequestStat { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=statdb;Trusted_Connection=True;");
        }
    }
}
