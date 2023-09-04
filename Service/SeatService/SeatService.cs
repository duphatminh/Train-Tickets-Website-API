using Microsoft.EntityFrameworkCore;
using TrainTicketsWebsite.Data;
using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.SeatService;

public class SeatService : ISeatService
{
    private readonly DataContext _context;
    
    public SeatService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<Seats>> GetAllSeats()
    {
        var seatsWithCabin = await _context.SeatsInfo
            .ToListAsync();
        
        return seatsWithCabin;
    }
    
    public async Task<Seats> GetSeat(int id)
    {
        var seatGet = await _context.SeatsInfo.SingleOrDefaultAsync(s => s.seatID == id);
        if (seatGet == null)
        {
            return null;
        }

        return seatGet;
    }
    
    public async Task<List<Seats>> CreateSeat(CreateSeatModel createSeatModel)
    {
        var newSeat = new Seats()
        {
            cabinID = createSeatModel.cabinID,
            seatNumber = createSeatModel.seatNumber,
            seatType = createSeatModel.seatType,
            seatAvailability = createSeatModel.seatAvailability,
            price = createSeatModel.price
        };
        
        _context.SeatsInfo.Add(newSeat);
        await _context.SaveChangesAsync();
        return await _context.SeatsInfo.ToListAsync();
    }
    
    public async Task<List<Seats>> UpdateSeat(int id, UpdateSeatModel updateSeatModel)
    {
        var seatUpdate = await _context.SeatsInfo.SingleOrDefaultAsync(s => s.seatID == id);
        if (seatUpdate == null)
        {
            return null;
        }
        else
        {
            seatUpdate.seatType = updateSeatModel.seatType;
            seatUpdate.seatAvailability = updateSeatModel.seatAvailability;
            seatUpdate.price = updateSeatModel.price;
            await _context.SaveChangesAsync();
            return await _context.SeatsInfo.ToListAsync();
        }
    }
    
    public async Task<List<Seats>> DeleteSeat(int id)
    {
        var seatDelete = await _context.SeatsInfo.SingleOrDefaultAsync(s => s.seatID == id);
        if (seatDelete == null)
        {
            return null;
        }
        else
        {
            _context.SeatsInfo.Remove(seatDelete);
            await _context.SaveChangesAsync();
            return await _context.SeatsInfo.ToListAsync();
        }
    }
}