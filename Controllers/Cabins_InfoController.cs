using Microsoft.AspNetCore.Mvc;
using TrainTicketsWebsite.Models;
using TrainTicketsWebsite.Service.CabinService;

namespace TrainTicketsWebsite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Cabins_InfoController : Controller
{
    private readonly ICabinService _cabinService;
    
    public Cabins_InfoController(ICabinService cabinService)
    {
        _cabinService = cabinService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Cabins>>> GetAllCabins()
    {
        return await _cabinService.GetAllCabins();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Cabins>> GetCabin(int id)
    {
        var result = await _cabinService.GetCabin(id);
        if (result is null)
            return NotFound("Cabin not found. ");
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<Cabins>>> CreateCabin(CreateCabinModel createCabinModel)
    {
        var result = await _cabinService.CreateCabin(createCabinModel);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Cabins>>> UpdateCabin(int id, UpdateCabinModel updateCabinModel)
    {
        var result = await _cabinService.UpdateCabin(id, updateCabinModel);
        if (result is null)
            return NotFound("Cabin not found. ");
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Cabins>>> DeleteCabin(int id)
    {
        var result = await _cabinService.DeleteCabin(id);
        if (result is null)
            return NotFound("Cabin not found. ");
        return Ok(result);
    }
}