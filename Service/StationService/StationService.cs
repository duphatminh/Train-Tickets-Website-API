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
    
    public async Task<List<StationsDetailModel>> GetAllStations()
    {
        var stations = await _context.Stations.ToListAsync();
        return stations;
    }
    
    public async Task<StationsDetailModel> GetStation(int id)
    {
        var stationGet = await _context.Stations.SingleOrDefaultAsync(s => s.stationID == id);
        if (stationGet == null)
        {
            return null;
        }

        return stationGet;
    }
    
    public async Task<List<StationsDetailModel>> CreateStation(CreateStationModel createStationModel)
    {
        var newStation = new StationsDetailModel()
        {
            stationName = createStationModel.stationName,
            stationLocation = createStationModel.stationLocation
        };
        
        _context.Stations.Add(newStation);
        await _context.SaveChangesAsync();
        return await _context.Stations.ToListAsync();
    }
    
    public async Task<List<StationsDetailModel>> UpdateStation(int id, UpdateStationModel updateStationModel)
    {
        var stationUpdate = await _context.Stations.SingleOrDefaultAsync(s => s.stationID == id);
        if (stationUpdate == null)
        {
            return null;
        }
        else
        {
            stationUpdate.stationLocation = updateStationModel.stationLocation;
            await _context.SaveChangesAsync();
            return await _context.Stations.ToListAsync();
        }
    }
    
    public async Task<List<StationsDetailModel>> DeleteStation(int id)
    {
        var stationDelete = await _context.Stations.SingleOrDefaultAsync(s => s.stationID == id);
        if (stationDelete == null)
        {
            return null;
        }
        else
        {
            _context.Stations.Remove(stationDelete);
            await _context.SaveChangesAsync();
            return await _context.Stations.ToListAsync();
        }
    }
}