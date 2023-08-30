using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.CarriageService;

public interface ICarriageService
{
    Task<List<CarriagesDetailsModel>> GetAllCarriages();
    Task<CarriagesDetailsModel> GetCarriage(int id);
    Task<List<CarriagesDetailsModel>> CreateCarriage(CreateCarriageModel createCarriageModel);
    Task<List<CarriagesDetailsModel>> UpdateCarriage(int id, UpdateCarriageModel updateCarriageModel);
    Task<List<CarriagesDetailsModel>> DeleteCarriage(int id);
}