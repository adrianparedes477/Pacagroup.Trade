﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pacagroup.Trade.Persistence.Contexts;

#nullable disable

namespace Pacagroup.Trade.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pacagroup.Trade.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .HasPrecision(9)
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasDefaultValue("USD");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<decimal>("Price")
                        .HasPrecision(9, 4)
                        .HasColumnType("decimal(9,4)");

                    b.Property<int>("Quanty")
                        .HasPrecision(9)
                        .HasColumnType("int");

                    b.Property<int>("Side")
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Text")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("TransactTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 11, 7, 14, 18, 49, 970, DateTimeKind.Local).AddTicks(8079),
                            CreatedBy = "system",
                            Currency = "USD",
                            Price = 522.99m,
                            Quanty = 1000,
                            Side = 0,
                            Symbol = "META",
                            Text = "",
                            TransactTime = new DateTime(2024, 11, 7, 14, 18, 49, 970, DateTimeKind.Local).AddTicks(8067),
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 11, 7, 14, 18, 49, 970, DateTimeKind.Local).AddTicks(8083),
                            CreatedBy = "system",
                            Currency = "USD",
                            Price = 324.30m,
                            Quanty = 300,
                            Side = 0,
                            Symbol = "MSFT",
                            Text = "",
                            TransactTime = new DateTime(2024, 11, 7, 14, 18, 49, 970, DateTimeKind.Local).AddTicks(8082),
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 11, 7, 14, 18, 49, 970, DateTimeKind.Local).AddTicks(8086),
                            CreatedBy = "system",
                            Currency = "USD",
                            Price = 0m,
                            Quanty = 400,
                            Side = 1,
                            Symbol = "AMZN",
                            Text = "",
                            TransactTime = new DateTime(2024, 11, 7, 14, 18, 49, 970, DateTimeKind.Local).AddTicks(8085),
                            Type = 1
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 11, 7, 14, 18, 49, 970, DateTimeKind.Local).AddTicks(8088),
                            CreatedBy = "system",
                            Currency = "USD",
                            Price = 0m,
                            Quanty = 800,
                            Side = 1,
                            Symbol = "TSLA",
                            Text = "",
                            TransactTime = new DateTime(2024, 11, 7, 14, 18, 49, 970, DateTimeKind.Local).AddTicks(8087),
                            Type = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
