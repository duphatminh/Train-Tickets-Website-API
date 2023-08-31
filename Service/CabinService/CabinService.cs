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
    
    public async Task<List<CabinsDetailModel>> GetAllCabins()
    {
        var cabins = await _context.CabinsInfo
            // .Include(cb => cb.CarriagesDetailModel)
            // .Include(cb => cb.Seats)
            .ToListAsync();
        return cabins;
    }
    
    public async Task<CabinsDetailModel> GetCabin(int id)
    {
        var cabinGet = await _context.CabinsInfo.SingleOrDefaultAsync(cg => cg.cabinID == id);
        if (cabinGet == null)
        {
            return null;
        }

        return cabinGet;
    }

    public async Task<List<CabinsDetailModel>> CreateCabin(CreateCabinModel createCabinModel)
    {
        var newCabin = new CabinsDetailModel()
        {
            carriageID = createCabinModel.carriageID,
            cabinName = createCabinModel.cabinName,
        };
        
        _context.CabinsInfo.Add(newCabin);
        await _context.SaveChangesAsync();
        return await _context.CabinsInfo.ToListAsync();
    }
    
    public async Task<List<CabinsDetailModel>> UpdateCabin(int id, UpdateCabinModel updateCabinModel)
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
    
    public async Task<List<CabinsDetailModel>> DeleteCabin(int id)
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