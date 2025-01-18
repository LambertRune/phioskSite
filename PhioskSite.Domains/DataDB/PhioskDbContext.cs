using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
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
        public DbSet<Address> Address { get; set; }
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
            modelBuilder.Entity<Phone>()
            .HasKey(p => p.Id);

            modelBuilder.Entity<Order>()
            .HasMany(e => e.Phones)
            .WithOne(e => e.Order)
            .HasForeignKey(e => e.OrderId);

            modelBuilder.Entity<User>()
           .HasMany(e => e.Orders)
           .WithOne(e => e.User)
           .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>(b =>
            {
                b.HasOne(u => u.Address)
                 .WithMany(a => a.Users)
                 .HasForeignKey(u => u.AddressId)
                 .OnDelete(DeleteBehavior.SetNull); // Optioneel: gedrag bij verwijdering van een adres
            });
            // Eventuele specifieke configuraties voor je modellen
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Phone>(b =>
            {
                b.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
                b.HasData(
                     new Phone
                     {
                         Id = 1,
                         PhoneName = "Galaxy S23",
                         Brand = "Samsung",
                         Price = 999.99m,
                         Color = "Phantom Black",
                         StorageCapacity = 256,
                         Description = "High-performance smartphone with a sleek design and powerful camera.",
                         ImageUrl = "/Images/frontPic1.svg",
                         AddedOn = new DateOnly(2025, 1, 1),
                         OrderId = 1,
                         Order = null
                     },
                     new Phone
                     {
                         Id = 2,
                         PhoneName = "iPhone 15",
                         Brand = "Apple",
                         Price = 1199.99m,
                         Color = "Starlight",
                         StorageCapacity = 512,
                         Description = "The latest iPhone with exceptional speed and a stunning display.",
                         ImageUrl = "/Images/frontPic1.svg",
                         AddedOn = new DateOnly(2025, 1, 2),
                         OrderId = 1,
                         Order = null
                     },
                     new Phone
                     {
                         Id = 3,
                         PhoneName = "Pixel 8 Pro",
                         Brand = "Google",
                         Price = 899.99m,
                         Color = "Obsidian",
                         StorageCapacity = 128,
                         Description = "Google's flagship smartphone with cutting-edge AI features.",
                         ImageUrl = "/Images/frontPic1.svg",
                         AddedOn = new DateOnly(2025, 1, 3),
                         OrderId = null,
                         Order = null
                     },
                     new Phone
                     {
                         Id = 4,
                         PhoneName = "Xperia 1 V",
                         Brand = "Sony",
                         Price = 1099.99m,
                         Color = "Frosted Silver",
                         StorageCapacity = 256,
                         Description = "A photography powerhouse with a stunning 4K OLED display.",
                         ImageUrl = "/Images/frontPic1.svg",
                         AddedOn = new DateOnly(2025, 1, 4),
                         OrderId = null,
                         Order = null
                     },
                     new Phone
                     {
                         Id = 5,
                         PhoneName = "OnePlus 12",
                         Brand = "OnePlus",
                         Price = 799.99m,
                         Color = "Volcanic Black",
                         StorageCapacity = 256,
                         Description = "A balanced combination of performance and value for tech enthusiasts.",
                         ImageUrl = "/Images/frontPic1.svg",
                         AddedOn = new DateOnly(2025, 1, 5),
                         OrderId = null,
                         Order = null
                     });
                modelBuilder.Entity<Order>(b =>
                {
                    b.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
                    b.HasData(
                        new Order
                        {
                            Id = 1,
                            InvoiceDate = new DateOnly(2025, 1, 1),
                            ExpireDate = new DateOnly(2025, 1, 15),
                            UserId = 1 // Verwijzing naar een bestaande User
                        },
                        new Order
                        {
                            Id = 2,
                            InvoiceDate = new DateOnly(2025, 1, 3),
                            ExpireDate = new DateOnly(2025, 1, 18),
                            UserId = 2 // Verwijzing naar een bestaande User
                        },
                        new Order
                        {
                            Id = 3,
                            InvoiceDate = new DateOnly(2025, 1, 5),
                            ExpireDate = new DateOnly(2025, 1, 20),
                            UserId = 3 // Verwijzing naar een bestaande User
                        },
                        new Order
                        {
                            Id=4,
                            InvoiceDate = new DateOnly(2025, 1, 5),
                            ExpireDate = new DateOnly(2025, 1, 20),
                            UserId = 3 // Verwijzing naar een bestaande User
                        }
                    );
                });
                modelBuilder.Entity<User>(b =>
                {
                    b.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
                    b.HasData(
                        new User
                        {
                            Id = 1,
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = "123-456-7890",
                            Mail = "john.doe@example.com",
                            AddressId = 101 // Verwijst naar een bestaand adres (bijvoorbeeld in een Address-tabel)
                        },
                        new User
                        {
                            Id = 2,
                            FirstName = "Jane",
                            LastName = "Smith",
                            Phone = "987-654-3210",
                            Mail = "jane.smith@example.com",
                            AddressId = 102 // Verwijst naar een ander adres
                        },
                        new User
                        {
                            Id = 3,
                            FirstName = "Alice",
                            LastName = "Johnson",
                            Phone = null, // Geen telefoonnummer beschikbaar
                            Mail = "alice.johnson@example.com",
                            AddressId = 103
                        },
                        new User
                        {
                            Id = 4,
                            FirstName = "Bob",
                            LastName = "Brown",
                            Phone = "555-123-4567",
                            Mail = "bob.brown@example.com",
                            AddressId = 104
                        },
                        new User
                        {
                            Id = 5,
                            FirstName = "Charlie",
                            LastName = "Davis",
                            Phone = "444-222-1111",
                            Mail = "charlie.davis@example.com",
                            AddressId = null // Geen adres gekoppeld
                        }
                    );
                });
                modelBuilder.Entity<Address>(b =>
                {
                    b.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
                    b.HasData(
                        new Address
                        {
                            Id = 101,
                            Street = "Main Street",
                            Number = "10",
                            City = "New York",
                            PostalCode = "10001",
                            Country = "USA"
                        },
                        new Address
                        {
                            Id = 102,
                            Street = "Elm Avenue",
                            Number = "25",
                            City = "Chicago",
                            PostalCode = "60614",
                            Country = "USA"
                        },
                        new Address
                        {
                            Id = 103,
                            Street = "Baker Street",
                            Number = "221B",
                            City = "London",
                            PostalCode = "NW1 6XE",
                            Country = "UK"
                        },
                        new Address
                        {
                            Id = 104,
                            Street = "Rue de Rivoli",
                            Number = "50",
                            City = "Paris",
                            PostalCode = "75001",
                            Country = "France"
                        },
                        new Address
                        {
                            Id = 105,
                            Street = "Avenue des Champs-Élysées",
                            Number = "110",
                            City = "Paris",
                            PostalCode = "75008",
                            Country = "France"
                        }
                    );
                });



            });
        }

    }
}
