using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace StatisticsUniqWordsHttp
{
    public class AppContext : DbContext
    {
        public DbSet<StatDb> statDb { get; set; }
        public DbSet<StatDetailDb> statWordsDb { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            //var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=statdb;Trusted_Connection=True;");
        }







    }
}
