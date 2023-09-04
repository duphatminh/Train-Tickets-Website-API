using Microsoft.AspNetCore.Mvc;
using TrainTicketsWebsite.Service.TrainService;

namespace TrainTicketsWebsite.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomePageContoller : Controller
{
    private readonly ITrainService _trainService;
    
    public HomePageContoller(ITrainService trainService)
    {
        _trainService = trainService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTrains()
    {
        var trains = await _trainService.GetAllTrains();
        return Ok(trains);
    }
}