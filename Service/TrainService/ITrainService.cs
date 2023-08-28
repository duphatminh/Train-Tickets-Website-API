using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.TrainService;

public interface ITrainService
{
    Task<List<TrainDetailsModel>> GetAllTrains();
    Task<TrainDetailsModel> GetTrain(int id);
    Task<List<TrainDetailsModel>> CreateTrain(CreateTrainModel createTrainModel);
    Task<List<TrainDetailsModel>> UpdateTrain(int id, UpdateTrainModel updateTrainModel);
    Task<List<TrainDetailsModel>> DeleteTrain(int id);
}