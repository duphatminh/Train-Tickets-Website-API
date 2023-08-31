using Microsoft.EntityFrameworkCore;
using TrainTicketsWebsite.Data;
using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.StationService;

public class StationService : IStationService
{
    private readonly DataContext _context;
    
    public StationService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<Stations>> GetAllStations()
    {
        var stations = await _context.StationsInfo.ToListAsync();
        return stations;
    }
    
    public async Task<Stations> GetStation(int id)
    {
        var stationGet = await _context.StationsInfo.SingleOrDefaultAsync(s => s.stationID == id);
        if (stationGet == null)
        {
            return null;
        }

        return stationGet;
    }
    
    public async Task<List<Stations>> CreateStation(CreateStationModel createStationModel)
    {
        var newStation = new Stations()
        {
            stationName = createStationModel.stationName,
            stationLocation = createStationModel.stationLocation
        };
        
        _context.StationsInfo.Add(newStation);
        await _context.SaveChangesAsync();
        return await _context.StationsInfo.ToListAsync();
    }
    
    public async Task<List<Stations>> UpdateStation(int id, UpdateStationModel updateStationModel)
    {
        var stationUpdate = await _context.StationsInfo.SingleOrDefaultAsync(s => s.stationID == id);
        if (stationUpdate == null)
        {
            return null;
        }
        else
        {
            stationUpdate.stationLocation = updateStationModel.stationLocation;
            await _context.SaveChangesAsync();
            return await _context.StationsInfo.ToListAsync();
        }
    }
    
    public async Task<List<Stations>> DeleteStation(int id)
    {
        var stationDelete = await _context.StationsInfo.SingleOrDefaultAsync(s => s.stationID == id);
        if (stationDelete == null)
        {
            return null;
        }
        else
        {
            _context.StationsInfo.Remove(stationDelete);
            await _context.SaveChangesAsync();
            return await _context.StationsInfo.ToListAsync();
        }
    }
}