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
    public async Task<List<TrainsDetailModel>> GetAllTrains()
    {
        var trains = await _context.TrainsInfo.ToListAsync();
        return trains; 
    }
    
    public async Task<TrainsDetailModel> GetTrain(int id)
    {
        var trainGet = await _context.TrainsInfo.SingleOrDefaultAsync(ts => ts.trainID == id);
        if (trainGet == null)
        {
            return null;
        }

        return trainGet;
    }
    
    public async Task<List<TrainsDetailModel>> CreateTrain(CreateTrainModel createTrainModel)
    {
        var newTrain = new TrainsDetailModel()
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
    
    public async Task<List<TrainsDetailModel>> UpdateTrain(int id, [FromBody] UpdateTrainModel updateTrainModel)
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
    
    public async Task<List<TrainsDetailModel>> DeleteTrain(int id)
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
}