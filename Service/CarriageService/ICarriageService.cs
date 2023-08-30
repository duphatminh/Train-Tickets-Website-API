using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.CarriageService;

public interface ICarriageService
{
    Task<List<CarriagesDetailModel>> GetAllCarriages();
    Task<CarriagesDetailModel> GetCarriage(int id);
    Task<List<CarriagesDetailModel>> CreateCarriage(CreateCarriageModel createCarriageModel);
    Task<List<CarriagesDetailModel>> UpdateCarriage(int id, UpdateCarriageModel updateCarriageModel);
    Task<List<CarriagesDetailModel>> DeleteCarriage(int id);
}