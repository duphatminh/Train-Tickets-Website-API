using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.TrainService;
// 
public interface ITrainService
{
    Task<List<Trains>> GetAllTrains();
    Task<Trains> GetTrain(int id);
    Task<List<Trains>> CreateTrain(CreateTrainModel createTrainModel);
    Task<List<Trains>> UpdateTrain(int id, UpdateTrainModel updateTrainModel);
    Task<List<Trains>> DeleteTrain(int id);
    
    Task<List<PopularTrainModel>> GetPopularTrains();
}