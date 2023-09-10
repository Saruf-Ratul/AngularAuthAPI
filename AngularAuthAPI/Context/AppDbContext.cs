using AngularAuthAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Reflection.Emit;

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
        public DbSet<Apoinment> Apoinments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("users");
            builder.Entity<Dashboard>().ToTable("dashboards");
            builder.Entity<Apoinment>().ToTable("Apoinments");
            builder.Entity<Apoinment>().HasKey(a => a.Id);
            builder.Entity<Apoinment>().Property(a => a.Id).ValueGeneratedOnAdd();
        }


    }
}
