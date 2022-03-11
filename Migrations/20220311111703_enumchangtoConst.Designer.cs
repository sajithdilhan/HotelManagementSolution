﻿// <auto-generated />
using CoreLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelManagementSolution.Migrations
{
    [DbContext(typeof(HotelDataContext))]
    [Migration("20220311111703_enumchangtoConst")]
    partial class enumchangtoConst
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreLibrary.Entities.HotelRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoomNumber = "1A",
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            RoomNumber = "1B",
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            RoomNumber = "1C",
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            RoomNumber = "1D",
                            Status = 0
                        },
                        new
                        {
                            Id = 5,
                            RoomNumber = "1E",
                            Status = 0
                        },
                        new
                        {
                            Id = 6,
                            RoomNumber = "2E",
                            Status = 0
                        },
                        new
                        {
                            Id = 7,
                            RoomNumber = "2D",
                            Status = 0
                        },
                        new
                        {
                            Id = 8,
                            RoomNumber = "2C",
                            Status = 0
                        },
                        new
                        {
                            Id = 9,
                            RoomNumber = "2B",
                            Status = 0
                        },
                        new
                        {
                            Id = 10,
                            RoomNumber = "2A",
                            Status = 0
                        },
                        new
                        {
                            Id = 11,
                            RoomNumber = "3A",
                            Status = 0
                        },
                        new
                        {
                            Id = 12,
                            RoomNumber = "3B",
                            Status = 0
                        },
                        new
                        {
                            Id = 13,
                            RoomNumber = "3C",
                            Status = 0
                        },
                        new
                        {
                            Id = 14,
                            RoomNumber = "3D",
                            Status = 0
                        },
                        new
                        {
                            Id = 15,
                            RoomNumber = "3E",
                            Status = 0
                        },
                        new
                        {
                            Id = 16,
                            RoomNumber = "4E",
                            Status = 0
                        },
                        new
                        {
                            Id = 17,
                            RoomNumber = "4D",
                            Status = 0
                        },
                        new
                        {
                            Id = 18,
                            RoomNumber = "4C",
                            Status = 0
                        },
                        new
                        {
                            Id = 19,
                            RoomNumber = "4B",
                            Status = 0
                        },
                        new
                        {
                            Id = 20,
                            RoomNumber = "4A",
                            Status = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}