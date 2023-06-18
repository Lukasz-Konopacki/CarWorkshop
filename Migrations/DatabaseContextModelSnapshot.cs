﻿// <auto-generated />
using System;
using CarWorkshop.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarWorkshop.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarWorkshop.Model.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(53)
                        .HasColumnType("nvarchar(53)");

                    b.Property<string>("FlatNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CarWorkshop.Model.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("PlateNumer")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("YearOfProduce")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarWorkshop.Model.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NipNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CarWorkshop.Model.Part", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("RepairId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RepairId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("CarWorkshop.Model.Repair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IncludeOilService")
                        .HasColumnType("bit");

                    b.Property<string>("ProblemDescriptionByClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("WorkingHours")
                        .HasColumnType("money");

                    b.Property<int>("kilometerage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("CarWorkshop.Model.Car", b =>
                {
                    b.HasOne("CarWorkshop.Model.Client", "Client")
                        .WithMany("Cars")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CarWorkshop.Model.Client", b =>
                {
                    b.HasOne("CarWorkshop.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("CarWorkshop.Model.Part", b =>
                {
                    b.HasOne("CarWorkshop.Model.Repair", "Repair")
                        .WithMany("Parts")
                        .HasForeignKey("RepairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Repair");
                });

            modelBuilder.Entity("CarWorkshop.Model.Repair", b =>
                {
                    b.HasOne("CarWorkshop.Model.Car", "Car")
                        .WithMany("Repairs")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarWorkshop.Model.Car", b =>
                {
                    b.Navigation("Repairs");
                });

            modelBuilder.Entity("CarWorkshop.Model.Client", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarWorkshop.Model.Repair", b =>
                {
                    b.Navigation("Parts");
                });
#pragma warning restore 612, 618
        }
    }
}
