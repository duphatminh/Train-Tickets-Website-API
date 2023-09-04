using Microsoft.EntityFrameworkCore;
using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Data;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(
            @"data source=WISERC-COMPUTER\SQLEXPRESS;
            initial catalog= TrainTicketsDB;
            user id=sa;
            password=123456;
            TrustServerCertificate=true;");
        optionsBuilder.EnableSensitiveDataLogging();
    }
    
    public DbSet<Trains> TrainsInfo { get; set; }
    
    public DbSet<Users> UsersInfo { get; set; }
    
    public DbSet<Carriages> CarriagesInfo { get; set; }
    
    public DbSet<Cabins> CabinsInfo { get; set; }
    
    public DbSet<Stations> StationsInfo { get; set; }
    
    public DbSet<Seats> SeatsInfo { get; set; }

    public DbSet<Bookings> BookingsInfo { get; set; }
    
    public DbSet<Payments> PaymentsInfo { get; set; }
}
