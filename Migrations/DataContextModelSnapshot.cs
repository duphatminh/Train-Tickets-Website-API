﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainTicketsWebsite.Data;

#nullable disable

namespace TrainTicketsWebsite.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrainTicketsWebsite.Models.Cabins", b =>
                {
                    b.Property<int>("cabinID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cabinID"));

                    b.Property<string>("cabinName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("carriageID")
                        .HasColumnType("int");

                    b.HasKey("cabinID");

                    b.HasIndex("carriageID");

                    b.ToTable("CabinsInfo");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.CarriagesDetailModel", b =>
                {
                    b.Property<int>("carriageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("carriageID"));

                    b.Property<string>("carriageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carriageStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carriageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("trainID")
                        .HasColumnType("int");

                    b.HasKey("carriageID");

                    b.HasIndex("trainID");

                    b.ToTable("CarriagesInfo");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Seats", b =>
                {
                    b.Property<int>("seatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("seatID"));

                    b.Property<int>("cabinID")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("seatAvailability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("seatNumber")
                        .HasColumnType("int");

                    b.Property<string>("seatType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("seatID");

                    b.HasIndex("cabinID");

                    b.ToTable("SeatsInfo");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.StationsDetailModel", b =>
                {
                    b.Property<int>("stationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("stationID"));

                    b.Property<string>("stationLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stationName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("stationID");

                    b.ToTable("StationsInfo");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.TrainsDetailModel", b =>
                {
                    b.Property<int>("trainID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("trainID"));

                    b.Property<string>("arrivalStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("arrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("departureStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("departureTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("schedule")
                        .HasColumnType("datetime2");

                    b.Property<int>("stationID")
                        .HasColumnType("int");

                    b.Property<string>("trainName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("trainID");

                    b.HasIndex("stationID");

                    b.ToTable("TrainsInfo");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Users", b =>
                {
                    b.Property<int>("user_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_ID"));

                    b.Property<string>("email")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_ID");

                    b.ToTable("UsersInfo");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Cabins", b =>
                {
                    b.HasOne("TrainTicketsWebsite.Models.CarriagesDetailModel", "CarriagesDetailModel")
                        .WithMany("Cabins")
                        .HasForeignKey("carriageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarriagesDetailModel");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.CarriagesDetailModel", b =>
                {
                    b.HasOne("TrainTicketsWebsite.Models.TrainsDetailModel", "TrainsDetailModel")
                        .WithMany("Carriages")
                        .HasForeignKey("trainID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainsDetailModel");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Seats", b =>
                {
                    b.HasOne("TrainTicketsWebsite.Models.Cabins", "Cabins")
                        .WithMany("Seats")
                        .HasForeignKey("cabinID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabins");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.TrainsDetailModel", b =>
                {
                    b.HasOne("TrainTicketsWebsite.Models.StationsDetailModel", "StationsDetailModel")
                        .WithMany("Trains")
                        .HasForeignKey("stationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StationsDetailModel");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Cabins", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.CarriagesDetailModel", b =>
                {
                    b.Navigation("Cabins");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.StationsDetailModel", b =>
                {
                    b.Navigation("Trains");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.TrainsDetailModel", b =>
                {
                    b.Navigation("Carriages");
                });
#pragma warning restore 612, 618
        }
    }
}
