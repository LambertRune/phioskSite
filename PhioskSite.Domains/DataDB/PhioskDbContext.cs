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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQL22_VIVES; Database=PhioskDB; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true;");

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
