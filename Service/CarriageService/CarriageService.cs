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
    
    public async Task<List<Carriages>> GetAllCarriages()
    {
        var carriagesWithCabins = await _context.CarriagesInfo
            .ToListAsync();
        
        return carriagesWithCabins;
    }
    
    public async Task<Carriages> GetCarriage(int id)
    {
        var carriageGet = await _context.CarriagesInfo.SingleOrDefaultAsync(cs => cs.carriageID == id);
        if (carriageGet == null)
        {
            return null;
        }

        return carriageGet;
    }
    
    public async Task<List<Carriages>> CreateCarriage(CreateCarriageModel createCarriageModel)
    {
        var newCarriage = new Carriages()
        {
            trainID = createCarriageModel.trainID,
            carriageName = createCarriageModel.carriageName,
            carriageType = createCarriageModel.carriageType,
            carriageStatus = createCarriageModel.carriageStatus
        };
        
        _context.CarriagesInfo.Add(newCarriage);
        await _context.SaveChangesAsync();
        return await _context.CarriagesInfo.ToListAsync();
    }
    
public async Task<List<Carriages>> UpdateCarriage(int id,UpdateCarriageModel updateCarriageModel)
    {
        var carriageUpdate = await _context.CarriagesInfo.SingleOrDefaultAsync(cs => cs.carriageID == id);
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
            return await _context.CarriagesInfo.ToListAsync();
        }
    }
    
    public async Task<List<Carriages>> DeleteCarriage(int id)
    {
        var carriageDelete = await _context.CarriagesInfo.SingleOrDefaultAsync(cs => cs.carriageID == id);
        if (carriageDelete == null)
        {
            return null;
        }
        else
        {
            _context.CarriagesInfo.Remove(carriageDelete);
            await _context.SaveChangesAsync();
            return await _context.CarriagesInfo.ToListAsync();
        }
    }
}