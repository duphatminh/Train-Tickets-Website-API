using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using TrainTicketsWebsite.Data;
using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.TrainService;

public class TrainService : ITrainService
{
    private readonly DataContext _context;
    public TrainService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Trains>> GetAllTrains()
    {
        var trainsWithStationsAndCarriages = await _context.TrainsInfo
            .ToListAsync();
        
        return trainsWithStationsAndCarriages;
    }
    
    public async Task<Trains> GetTrain(int id)
    {
        var trainGet = await _context.TrainsInfo.SingleOrDefaultAsync(ts => ts.trainID == id);
        if (trainGet == null)
        {
            return null;
        }

        return trainGet;
    }
    
    public async Task<List<Trains>> CreateTrain(CreateTrainModel createTrainModel)
    {
        var newTrain = new Trains()
        {
            stationID = createTrainModel.stationID,
            trainName = createTrainModel.trainName,
            departureStation = createTrainModel.departureStation,
            arrivalStation = createTrainModel.arrivalStation
        };
            
        _context.TrainsInfo.Add(newTrain);
        await _context.SaveChangesAsync();
        return await _context.TrainsInfo.ToListAsync();
    }
    
    public async Task<List<Trains>> UpdateTrain(int id, [FromBody] UpdateTrainModel updateTrainModel)
    {
        var trainUpdate = await _context.TrainsInfo.SingleOrDefaultAsync(ts => ts.trainID == id);
        if (trainUpdate == null)
        {
            return null;
        }
        else
        {
            trainUpdate.departureStation = updateTrainModel.departureStation;
            trainUpdate.arrivalStation = updateTrainModel.arrivalStation;
            trainUpdate.departureTime = updateTrainModel.departureTime;
            trainUpdate.arrivalTime = updateTrainModel.arrivalTime;
                
            await _context.SaveChangesAsync();
            return await _context.TrainsInfo.ToListAsync();
        }
    }
    
    public async Task<List<Trains>> DeleteTrain(int id)
    {  
        var trainDelete = await _context.TrainsInfo.SingleOrDefaultAsync(ts => ts.trainID == id);
        if (trainDelete == null)
        {
            return null;
        }
        else
        {
            _context.TrainsInfo.Remove(trainDelete);
            await _context.SaveChangesAsync();
            return await _context.TrainsInfo.ToListAsync();
        }
    }
    
    public async Task<List<PopularTrainModel>> GetPopularTrains()
    {
        var popularTrains = await _context.TrainsInfo
            .GroupBy(ts => ts.trainID)
            .Select(ts => new PopularTrainModel
            {
                trainID = ts.Key,
                trainName = ts.Select(ts => ts.trainName).FirstOrDefault(),
                numberOfBooking = _context.BookingsInfo.Count(bi => bi.seatID == ts.Key)
            })
            .OrderByDescending(ts => ts.numberOfBooking)
            .ToListAsync();
        
        return popularTrains;
    }
}