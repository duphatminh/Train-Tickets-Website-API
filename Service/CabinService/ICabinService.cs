using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Service.CabinService;

public interface ICabinService
{
    Task<List<Cabins>> GetAllCabins();
    Task<Cabins> GetCabin(int id);
    Task<List<Cabins>> CreateCabin(CreateCabinModel createCabinModel);
    Task<List<Cabins>> UpdateCabin(int id, UpdateCabinModel updateCabinModel);
    Task<List<Cabins>> DeleteCabin(int id);
}