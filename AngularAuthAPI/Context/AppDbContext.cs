using AngularAuthAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AngularAuthAPI.Context
{
    public class AppDbContext : DbContext
    {
        public class ReadJson
        {
            public string ConString { get; set; }
        }

        private static string _connectionString = string.Empty;
        public AppDbContext()
        {
            if (_connectionString == string.Empty)
            {
                using StreamReader r = new StreamReader("appsettings.json");
                string json = r.ReadToEnd();
                var item = JsonConvert.DeserializeObject<ReadJson>(json);
                _connectionString = item.ConString;
            }
        }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("users");
            builder.Entity<Dashboard>().ToTable("dashboards");
        }
    }
}
