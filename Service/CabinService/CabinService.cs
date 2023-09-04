using Microsoft.EntityFrameworkCore;
using TrainTicketsWebsite.Data;
using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.CabinService;

public class CabinService : ICabinService
{
    private readonly DataContext _context;
    
    public CabinService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<Cabins>> GetAllCabins()
    {
        var cabinsWithSeats = await _context.CabinsInfo
            .ToListAsync();
        
        return cabinsWithSeats;
    }
    
    public async Task<Cabins> GetCabin(int id)
    {
        var cabinGet = await _context.CabinsInfo.SingleOrDefaultAsync(cg => cg.cabinID == id);
        if (cabinGet == null)
        {
            return null;
        }

        return cabinGet;
    }

    public async Task<List<Cabins>> CreateCabin(CreateCabinModel createCabinModel)
    {
        var newCabin = new Cabins()
        {
            carriageID = createCabinModel.carriageID,
            cabinName = createCabinModel.cabinName,
        };
        
        _context.CabinsInfo.Add(newCabin);
        await _context.SaveChangesAsync();
        return await _context.CabinsInfo.ToListAsync();
    }
    
    public async Task<List<Cabins>> UpdateCabin(int id, UpdateCabinModel updateCabinModel)
    {
        var cabinUpdate = await _context.CabinsInfo.SingleOrDefaultAsync(cg => cg.cabinID == id);
        if (cabinUpdate == null)
        {
            return null;
        }
        else
        {
            cabinUpdate.cabinName = updateCabinModel.cabinName;
            await _context.SaveChangesAsync();
            return await _context.CabinsInfo.ToListAsync();
        }
    }
    
    public async Task<List<Cabins>> DeleteCabin(int id)
    {
        var cabinDelete = await _context.CabinsInfo.SingleOrDefaultAsync(cg => cg.cabinID == id);
        if (cabinDelete == null)
        {
            return null;
        }
        else
        {
            _context.CabinsInfo.Remove(cabinDelete);
            await _context.SaveChangesAsync();
            return await _context.CabinsInfo.ToListAsync();
        }
    }
}