using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.SeatService;

public interface ISeatService
{
    Task<List<Seats>> GetAllSeats();
    Task<Seats> GetSeat(int id);
    Task<List<Seats>> CreateSeat(CreateSeatModel createSeatModel);
    Task<List<Seats>> UpdateSeat(int id, UpdateSeatModel updateSeatModel);
    Task<List<Seats>> DeleteSeat(int id);
}