using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.StationService;

public interface IStationService
{
    Task<List<StationsDetailModel>> GetAllStations();
    Task<StationsDetailModel> GetStation(int id);
    Task<List<StationsDetailModel>> CreateStation(CreateStationModel createStationModel);
    Task<List<StationsDetailModel>> UpdateStation(int id, UpdateStationModel updateStationModel);
    Task<List<StationsDetailModel>> DeleteStation(int id);
}