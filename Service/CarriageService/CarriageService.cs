using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainTicketsWebsite.Data;
using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.CarriageService;

public class CarriageService : ICarriageService
{
    private readonly DataContext _context;
    
    public CarriageService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<CarriagesDetailModel>> GetAllCarriages()
    {
        var carriages = await _context.Carriages.ToListAsync();
        return carriages;
    }
    
    public async Task<CarriagesDetailModel> GetCarriage(int id)
    {
        var carriageGet = await _context.Carriages.SingleOrDefaultAsync(cs => cs.carriageID == id);
        if (carriageGet == null)
        {
            return null;
        }

        return carriageGet;
    }
    
    public async Task<List<CarriagesDetailModel>> CreateCarriage(CreateCarriageModel createCarriageModel)
    {
        var newCarriage = new CarriagesDetailModel()
        {
            trainID = createCarriageModel.trainID,
            carriageName = createCarriageModel.carriageName,
            carriageType = createCarriageModel.carriageType,
            carriageStatus = createCarriageModel.carriageStatus
        };
        
        _context.Carriages.Add(newCarriage);
        await _context.SaveChangesAsync();
        return await _context.Carriages.ToListAsync();
    }
    
public async Task<List<CarriagesDetailModel>> UpdateCarriage(int id,UpdateCarriageModel updateCarriageModel)
    {
        var carriageUpdate = await _context.Carriages.SingleOrDefaultAsync(cs => cs.carriageID == id);
        if (carriageUpdate == null)
        {
            return null;
        }
        else
        {
            carriageUpdate.carriageName = updateCarriageModel.carriageName;
            carriageUpdate.carriageType = updateCarriageModel.carriageType;
            carriageUpdate.carriageStatus = updateCarriageModel.carriageStatus;
            await _context.SaveChangesAsync();
            return await _context.Carriages.ToListAsync();
        }
    }
    
    public async Task<List<CarriagesDetailModel>> DeleteCarriage(int id)
    {
        var carriageDelete = await _context.Carriages.SingleOrDefaultAsync(cs => cs.carriageID == id);
        if (carriageDelete == null)
        {
            return null;
        }
        else
        {
            _context.Carriages.Remove(carriageDelete);
            await _context.SaveChangesAsync();
            return await _context.Carriages.ToListAsync();
        }
    }
}