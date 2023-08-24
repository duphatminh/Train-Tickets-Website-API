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
    
    public DbSet<TrainDetailsModel> Trains { get; set; }
    
    public DbSet<Users> Users { get; set; }
    
    public DbSet<Carriages> Carriages { get; set; }
    
    public DbSet<Cabins> Cabins { get; set; }
    
    public DbSet<Stations> Stations { get; set; }
    
    public DbSet<Seats> Seats { get; set; }

    
}
