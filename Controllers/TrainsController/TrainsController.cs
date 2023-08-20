using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TrainTicketsWebsite.Data;
using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private readonly DataContext _context;
        public TrainsController(DataContext context)
        {
            _context = context;
        }
        // GET: api/TrainControllers
        [HttpGet]
        public async Task<IActionResult> GetAllTrains()
        {
            var trains = await _context.Trains.ToListAsync();
            return Ok(trains); 
        }

        // GET: api/TrainControllers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrain(int id)
        {
            var trainGet = await _context.Trains.SingleOrDefaultAsync(ts => ts.trainID == id);
            if (trainGet == null)
            {
                return NotFound($"No record found against this Id {id}");
            }
            else
            {
                return Ok(trainGet);
            }
        }
        
        // GET: api/TrainControllers/SortTrains
        [HttpGet("SortTrains")]
        public async Task<IActionResult> SortTrains()
        {
            var trainsSort = await _context.Trains.OrderBy(ts => ts.trainName).ToListAsync();
            return Ok(trainsSort);
        }
        
        // POST: api/TrainControllers
        [HttpPost]
        public async Task<IActionResult> CreateTrain([FromBody] Trains trains)
        {
            _context.Trains.Add(trains);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/TrainControllers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrain(int id, [FromBody] Trains trains)
        {
            var trainUpdate = await _context.Trains.SingleOrDefaultAsync(ts => ts.trainID == id);
            if (trainUpdate == null)
            {
                return NotFound($"No record found against this Id {id}");
            }
            else
            {
                trainUpdate.trainName = trains.trainName;
                trainUpdate.departureStation = trains.departureStation;
                trainUpdate.arrivalStation = trains.arrivalStation;
                
                await _context.SaveChangesAsync();
                return Ok("Update Success");
            }
        }

        // DELETE: api/TrainControllers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {  
            var trainDelete = await _context.Trains.SingleOrDefaultAsync(ts => ts.trainID == id);
            if (trainDelete == null)
            {
                return NotFound($"No record found against this Id {id}");
            }
            else
            {
                _context.Trains.Remove(trainDelete);
                await _context.SaveChangesAsync();
                return Ok("Delete Success");
            }
        }
    }
}
