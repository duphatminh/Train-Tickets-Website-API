using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTicketsWebsite.Data;
using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly DataContext _context;
        public SeatsController(DataContext context)
        {
            _context = context;
        }
        
        // GET: api/Seats
        [HttpGet]
        public IActionResult GetAllSeats()
        {
            var seats = _context.Seats.ToList();
            return Ok(seats);
        }

        // GET: api/Seats/5
        [HttpGet("{id}")]
        public string GetSeat(int id)
        {
            return "value";
        }

        // POST: api/Seats
        [HttpPost]
        public IActionResult CreateSeats([FromBody] Seats seats)
        {
            _context.Seats.Add(seats);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Seats/5
        [HttpPut("{id}")]
        public void UpdateSeat(int id, [FromBody] string value)
        {
            
        }

        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
        public void UpdateSeat(int id)
        {
        }
    }
}
