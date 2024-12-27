using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PhioskSite.Domains.EntitiesDB;

namespace PhioskSite.Domains.DataDB;

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
        var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect("server=mssql004.db.hosting;database=ID456842_phiosk;user=ID456842_phiosk;password=W3LaMbw!9!huqFi"));
        optionsBuilder.UseMySql("server=mssql004.db.hosting;database=ID456842_phiosk;user=ID456842_phiosk;password=W3LaMbw!9!huqFi", serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceNo);

            entity.ToTable("Invoice");

            entity.Property(e => e.InvoiceNo).ValueGeneratedNever();

            entity.HasOne(d => d.AccountNoNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.AccountNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_UserAccount");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.ToTable("Phone");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PhoneName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StorageCapacity).HasColumnName("storageCapacity");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.ToTable("UserAccount");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
