using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.CabinService;

public interface ICabinService
{
    Task<List<CabinsDetailModel>> GetAllCabins();
    Task<CabinsDetailModel> GetCabin(int id);
    Task<List<CabinsDetailModel>> CreateCabin(CreateCabinModel createCabinModel);
    Task<List<CabinsDetailModel>> UpdateCabin(int id, UpdateCabinModel updateCabinModel);
    Task<List<CabinsDetailModel>> DeleteCabin(int id);
}