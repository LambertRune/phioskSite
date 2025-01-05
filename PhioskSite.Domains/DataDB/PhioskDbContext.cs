using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PhioskSite.Domains.EntitiesDB;

namespace PhioskSite.Domains.DataDB
{
    public partial class PhioskDbContext : DbContext
    {
        public PhioskDbContext()
        {
        }

        public PhioskDbContext(DbContextOptions<PhioskDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use configuration or environment variables
                optionsBuilder.UseSqlServer(
                    Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                    ?? "Your fallback connection string here");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Invoice");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.UserAccount).WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.AccountNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_UserAccount");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("Phone");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Brand).HasMaxLength(50);
                entity.Property(e => e.Color).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.ImageUrl).HasMaxLength(50);
                entity.Property(e => e.PhoneName).HasMaxLength(50);
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.StorageCapacity).HasColumnName("StorageCapacity");

                entity.HasOne(d => d.Invoice).WithMany(p => p.Phones)
                    .HasForeignKey(d => d.InvoiceNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phone_Invoice");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("UserAccount");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Mail).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
