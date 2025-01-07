﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhioskSite.Domains.DataDB;

#nullable disable

namespace PhioskSite.Domains.Migrations
{
    [DbContext(typeof(PhioskDbContext))]
    [Migration("20250107175840_AddaddressRelations")]
    partial class AddaddressRelations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PhioskSite.Domains.EntitiesDB.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            City = "New York",
                            Country = "USA",
                            Number = "10",
                            PostalCode = "10001",
                            Street = "Main Street"
                        },
                        new
                        {
                            Id = 102,
                            City = "Chicago",
                            Country = "USA",
                            Number = "25",
                            PostalCode = "60614",
                            Street = "Elm Avenue"
                        },
                        new
                        {
                            Id = 103,
                            City = "London",
                            Country = "UK",
                            Number = "221B",
                            PostalCode = "NW1 6XE",
                            Street = "Baker Street"
                        },
                        new
                        {
                            Id = 104,
                            City = "Paris",
                            Country = "France",
                            Number = "50",
                            PostalCode = "75001",
                            Street = "Rue de Rivoli"
                        },
                        new
                        {
                            Id = 105,
                            City = "Paris",
                            Country = "France",
                            Number = "110",
                            PostalCode = "75008",
                            Street = "Avenue des Champs-Élysées"
                        });
                });

            modelBuilder.Entity("PhioskSite.Domains.EntitiesDB.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("ExpireDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("InvoiceDate")
                        .HasColumnType("date");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExpireDate = new DateOnly(2025, 1, 15),
                            InvoiceDate = new DateOnly(2025, 1, 1),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExpireDate = new DateOnly(2025, 1, 18),
                            InvoiceDate = new DateOnly(2025, 1, 3),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            ExpireDate = new DateOnly(2025, 1, 20),
                            InvoiceDate = new DateOnly(2025, 1, 5),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("PhioskSite.Domains.EntitiesDB.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("AddedOn")
                        .HasColumnType("date");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("StorageCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedOn = new DateOnly(2025, 1, 1),
                            Brand = "Samsung",
                            Color = "Phantom Black",
                            Description = "High-performance smartphone with a sleek design and powerful camera.",
                            ImageUrl = "https://example.com/images/galaxy_s23.jpg",
                            PhoneName = "Galaxy S23",
                            Price = 999.99m,
                            StorageCapacity = 256
                        },
                        new
                        {
                            Id = 2,
                            AddedOn = new DateOnly(2025, 1, 2),
                            Brand = "Apple",
                            Color = "Starlight",
                            Description = "The latest iPhone with exceptional speed and a stunning display.",
                            ImageUrl = "https://example.com/images/iphone_15.jpg",
                            PhoneName = "iPhone 15",
                            Price = 1199.99m,
                            StorageCapacity = 512
                        },
                        new
                        {
                            Id = 3,
                            AddedOn = new DateOnly(2025, 1, 3),
                            Brand = "Google",
                            Color = "Obsidian",
                            Description = "Google's flagship smartphone with cutting-edge AI features.",
                            ImageUrl = "https://example.com/images/pixel_8_pro.jpg",
                            PhoneName = "Pixel 8 Pro",
                            Price = 899.99m,
                            StorageCapacity = 128
                        },
                        new
                        {
                            Id = 4,
                            AddedOn = new DateOnly(2025, 1, 4),
                            Brand = "Sony",
                            Color = "Frosted Silver",
                            Description = "A photography powerhouse with a stunning 4K OLED display.",
                            ImageUrl = "https://example.com/images/xperia_1_v.jpg",
                            PhoneName = "Xperia 1 V",
                            Price = 1099.99m,
                            StorageCapacity = 256
                        },
                        new
                        {
                            Id = 5,
                            AddedOn = new DateOnly(2025, 1, 5),
                            Brand = "OnePlus",
                            Color = "Volcanic Black",
                            Description = "A balanced combination of performance and value for tech enthusiasts.",
                            ImageUrl = "https://example.com/images/oneplus_12.jpg",
                            PhoneName = "OnePlus 12",
                            Price = 799.99m,
                            StorageCapacity = 256
                        });
                });

            modelBuilder.Entity("PhioskSite.Domains.EntitiesDB.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 101,
                            FirstName = "John",
                            LastName = "Doe",
                            Mail = "john.doe@example.com",
                            Phone = "123-456-7890"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 102,
                            FirstName = "Jane",
                            LastName = "Smith",
                            Mail = "jane.smith@example.com",
                            Phone = "987-654-3210"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 103,
                            FirstName = "Alice",
                            LastName = "Johnson",
                            Mail = "alice.johnson@example.com"
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 104,
                            FirstName = "Bob",
                            LastName = "Brown",
                            Mail = "bob.brown@example.com",
                            Phone = "555-123-4567"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Charlie",
                            LastName = "Davis",
                            Mail = "charlie.davis@example.com",
                            Phone = "444-222-1111"
                        });
                });

            modelBuilder.Entity("PhioskSite.Domains.EntitiesDB.Order", b =>
                {
                    b.HasOne("PhioskSite.Domains.EntitiesDB.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PhioskSite.Domains.EntitiesDB.Phone", b =>
                {
                    b.HasOne("PhioskSite.Domains.EntitiesDB.Order", "Order")
                        .WithMany("Phones")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PhioskSite.Domains.EntitiesDB.User", b =>
                {
                    b.HasOne("PhioskSite.Domains.EntitiesDB.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Address");
                });

            modelBuilder.Entity("PhioskSite.Domains.EntitiesDB.Address", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PhioskSite.Domains.EntitiesDB.Order", b =>
                {
                    b.Navigation("Phones");
                });

            modelBuilder.Entity("PhioskSite.Domains.EntitiesDB.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
