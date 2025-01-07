using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PhioskSite.Domains.EntitiesDB;

namespace PhioskSite.Domains.DataDB
{
    public class PhioskDbContext : DbContext
    {
        
        public PhioskDbContext()
        {           
        }

        public PhioskDbContext(DbContextOptions<PhioskDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var serverVersion = ServerVersion.AutoDetect("Server=127.0.0.1;Database=PhioskDB;User=root;Password=Berline2014;Port=3306;");
                // Use configuration or environment variables
                optionsBuilder.UseMySql("Server=127.0.0.1;Database=PhioskDB;User=root;Password=yourpassword;Port=3306;",serverVersion);

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Eventuele specifieke configuraties voor je modellen
            base.OnModelCreating(modelBuilder);
        }

    }
}
