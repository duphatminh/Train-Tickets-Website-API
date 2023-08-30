using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTicketsWebsite.Models;
using TrainTicketsWebsite.Service.CarriageService;

namespace TrainTicketsWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriagesController : ControllerBase
    {
        private readonly ICarriageService _carriageService;
        
        public CarriagesController(ICarriageService carriageService)
        {
            _carriageService = carriageService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<CarriagesDetailModel>>> GetAllCarriages()
        {
            return await _carriageService.GetAllCarriages();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CarriagesDetailModel>> GetCarriage(int id)
        {
            var result = await _carriageService.GetCarriage(id);
            if (result is null)
                return NotFound("Carriage not found. ");
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult<List<CarriagesDetailModel>>> CreateCarriage(CreateCarriageModel createCarriageModel)
        {
            var result = await _carriageService.CreateCarriage(createCarriageModel);
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<List<CarriagesDetailModel>>> UpdateCarriage(int id, UpdateCarriageModel updateCarriageModel)
        {
            var result = await _carriageService.UpdateCarriage(id, updateCarriageModel);
            if (result is null)
                return NotFound("Carriage not found. ");
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CarriagesDetailModel>>> DeleteCarriage(int id)
        {
            var result = await _carriageService.DeleteCarriage(id);
            if (result is null)
                return NotFound("Carriage not found. ");
            return Ok(result);
        }
        
    }
}
