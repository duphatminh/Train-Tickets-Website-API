using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.CarriageService;

public interface ICarriageService
{
    Task<List<Carriages>> GetAllCarriages();
    Task<Carriages> GetCarriage(int id);
    Task<List<Carriages>> CreateCarriage(CreateCarriageModel createCarriageModel);
    Task<List<Carriages>> UpdateCarriage(int id, UpdateCarriageModel updateCarriageModel);
    Task<List<Carriages>> DeleteCarriage(int id);
}