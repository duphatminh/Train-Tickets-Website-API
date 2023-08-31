using Microsoft.AspNetCore.Mvc;
using TrainTicketsWebsite.Models;
using TrainTicketsWebsite.Service.StationService;

namespace TrainTicketsWebsite.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Stations_InfoController : Controller
{
    private readonly IStationService _stationService;

    public Stations_InfoController(IStationService stationService)
    {
        _stationService = stationService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Stations>>> GetAllStations()
    {
        return await _stationService.GetAllStations();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Stations>> GetStation(int id)
    {
        var result = await _stationService.GetStation(id);
        if (result is null)
            return NotFound("Station not found. ");
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<Stations>>> CreateStation(CreateStationModel createStationModel)
    {
        var result = await _stationService.CreateStation(createStationModel);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Stations>>> UpdateStation(int id, UpdateStationModel updateStationModel)
    {
        var result = await _stationService.UpdateStation(id, updateStationModel);
        if (result is null)
            return NotFound("Station not found. ");
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Stations>>> DeleteStation(int id)
    {
        var result = await _stationService.DeleteStation(id);
        if (result is null)
            return NotFound("Station not found. ");
        return Ok(result);
    }
}

