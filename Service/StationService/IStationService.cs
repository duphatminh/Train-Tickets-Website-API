using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.StationService;

public interface IStationService
{
    Task<List<Stations>> GetAllStations();
    Task<Stations> GetStation(int id);
    Task<List<Stations>> CreateStation(CreateStationModel createStationModel);
    Task<List<Stations>> UpdateStation(int id, UpdateStationModel updateStationModel);
    Task<List<Stations>> DeleteStation(int id);
}