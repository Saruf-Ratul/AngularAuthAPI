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
        public DbSet<tbAppointment> tbAppointment { get; set; }
        public DbSet<tbAppType> tbAppType { get; set; }
        public DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<FoodMaster> FoodMaster { get; set; }
        public DbSet<DailyFood> DailyFood { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Printer> Printer { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("users");
            builder.Entity<Dashboard>().ToTable("dashboards");
            builder.Entity<Apoinment>().ToTable("Apoinments");
            builder.Entity<Apoinment>().HasKey(a => a.Id);
            builder.Entity<Apoinment>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<tbAppointment>().ToTable("tbAppointment");
            builder.Entity<tbAppointment>().HasKey(appointment => appointment.App_ID);
            builder.Entity<tbAppType>().ToTable("tbAppType");
            builder.Entity<tbAppType>().HasKey(appointmentType => appointmentType.App_TypeId);
            builder.Entity<EmployeeMaster>().ToTable("EmployeeMaster");
            builder.Entity<EmployeeMaster>().HasKey(a => a.Id);
            builder.Entity<EmployeeMaster>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<ServiceType>().ToTable("ServiceType");
            builder.Entity<ServiceType>().HasKey(a => a.Id);
            builder.Entity<ServiceType>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<FoodMaster>().ToTable("FoodMaster");
            builder.Entity<FoodMaster>().HasKey(a => a.Id);
            builder.Entity<FoodMaster>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<DailyFood>().ToTable("DailyFood");
            builder.Entity<DailyFood>().HasKey(a => a.Id);
            builder.Entity<DailyFood>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<Account>().ToTable("Account");
            builder.Entity<Account>().HasKey(a => a.Id);
            builder.Entity<Account>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<Ticket>().ToTable("Ticket");
            builder.Entity<Ticket>().HasKey(a => a.Id);
            builder.Entity<Printer>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<Printer>().ToTable("Printer");
            builder.Entity<Printer>().HasKey(a => a.Id);
            builder.Entity<Printer>().Property(a => a.Id).ValueGeneratedOnAdd();
        }


    }
}
