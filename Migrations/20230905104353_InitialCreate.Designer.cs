﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainTicketsWebsite.Data;

#nullable disable

namespace TrainTicketsWebsite.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230905104353_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrainTicketsWebsite.Models.Bookings", b =>
                {
                    b.Property<int>("bookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookingID"));

                    b.Property<string>("arrivalStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("departureStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("departureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("numberOfTickets")
                        .HasColumnType("int");

                    b.Property<int>("seatID")
                        .HasColumnType("int");

                    b.Property<int>("totalPrice")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("bookingID");

                    b.HasIndex("seatID");

                    b.HasIndex("userID");

                    b.ToTable("BookingsInfo");
                });

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

            modelBuilder.Entity("TrainTicketsWebsite.Models.Carriages", b =>
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

            modelBuilder.Entity("TrainTicketsWebsite.Models.Payments", b =>
                {
                    b.Property<int>("paymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("paymentID"));

                    b.Property<string>("creditCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cvv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("expirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("paymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("paymentID");

                    b.ToTable("PaymentsInfo");
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

            modelBuilder.Entity("TrainTicketsWebsite.Models.Stations", b =>
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

            modelBuilder.Entity("TrainTicketsWebsite.Models.Trains", b =>
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
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"));

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

                    b.HasKey("userID");

                    b.ToTable("UsersInfo");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Bookings", b =>
                {
                    b.HasOne("TrainTicketsWebsite.Models.Seats", "Seats")
                        .WithMany("Bookings")
                        .HasForeignKey("seatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTicketsWebsite.Models.Users", "Users")
                        .WithMany("Bookings")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seats");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Cabins", b =>
                {
                    b.HasOne("TrainTicketsWebsite.Models.Carriages", "Carriages")
                        .WithMany("Cabins")
                        .HasForeignKey("carriageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carriages");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Carriages", b =>
                {
                    b.HasOne("TrainTicketsWebsite.Models.Trains", "Trains")
                        .WithMany("Carriages")
                        .HasForeignKey("trainID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trains");
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

            modelBuilder.Entity("TrainTicketsWebsite.Models.Trains", b =>
                {
                    b.HasOne("TrainTicketsWebsite.Models.Stations", "Stations")
                        .WithMany("Trains")
                        .HasForeignKey("stationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stations");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Cabins", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Carriages", b =>
                {
                    b.Navigation("Cabins");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Seats", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Stations", b =>
                {
                    b.Navigation("Trains");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Trains", b =>
                {
                    b.Navigation("Carriages");
                });

            modelBuilder.Entity("TrainTicketsWebsite.Models.Users", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}