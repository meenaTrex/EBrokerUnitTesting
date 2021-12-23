﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryManagement;

namespace RepositoryManagement.Migrations
{
    [DbContext(typeof(TraderContext))]
    partial class TraderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shared.Models.Fund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("TraderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Funds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 200000.0,
                            TraderId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1500000.0,
                            TraderId = 2
                        },
                        new
                        {
                            Id = 3,
                            Amount = 250000.0,
                            TraderId = 3
                        });
                });

            modelBuilder.Entity("Shared.Models.Trader", b =>
                {
                    b.Property<int>("TraderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TraderId");

                    b.ToTable("Traders");

                    b.HasData(
                        new
                        {
                            TraderId = 1,
                            Name = "Chris"
                        },
                        new
                        {
                            TraderId = 2,
                            Name = "Alisha"
                        },
                        new
                        {
                            TraderId = 3,
                            Name = "Dodger"
                        });
                });

            modelBuilder.Entity("Shared.Models.TraderEquity", b =>
                {
                    b.Property<int>("TraderEquityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TraderId")
                        .HasColumnType("int");

                    b.HasKey("TraderEquityId");

                    b.ToTable("TraderEquities");
                });
#pragma warning restore 612, 618
        }
    }
}
