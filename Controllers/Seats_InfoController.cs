using Microsoft.AspNetCore.Mvc;
using TrainTicketsWebsite.Models;
using TrainTicketsWebsite.Service.SeatService;

namespace TrainTicketsWebsite.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Seats_InfoController : Controller
{
    private readonly ISeatService _seatService;
    
    public Seats_InfoController(ISeatService seatService)
    {
        _seatService = seatService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllSeats()
    {
        var seats = await _seatService.GetAllSeats();
        return Ok(seats);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSeat(int id)
    {
        var seat = await _seatService.GetSeat(id);
        if (seat == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(seat);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateSeat(CreateSeatModel createSeatModel)
    {
        var seats = await _seatService.CreateSeat(createSeatModel);
        return Ok(seats);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSeat(int id, UpdateSeatModel updateSeatModel)
    {
        var seats = await _seatService.UpdateSeat(id, updateSeatModel);
        if (seats == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(seats);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSeat(int id)
    {
        var seats = await _seatService.DeleteSeat(id);
        if (seats == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(seats);
        }
    }
}