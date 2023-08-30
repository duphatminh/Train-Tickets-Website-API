using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.TrainService;

public interface ITrainService
{
    Task<List<TrainsDetailModel>> GetAllTrains();
    Task<TrainsDetailModel> GetTrain(int id);
    Task<List<TrainsDetailModel>> CreateTrain(CreateTrainModel createTrainModel);
    Task<List<TrainsDetailModel>> UpdateTrain(int id, UpdateTrainModel updateTrainModel);
    Task<List<TrainsDetailModel>> DeleteTrain(int id);
}