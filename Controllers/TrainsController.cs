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
using TrainTicketsWebsite.Service.TrainService;

namespace TrainTicketsWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private readonly ITrainService _trainService;
        
        public TrainsController(ITrainService trainService)
        {
            _trainService = trainService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<TrainDetailsModel>>> GetAllTrains()
        {
            return await _trainService.GetAllTrains();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainDetailsModel>> GetTrain(int id)
        {
            var result = await _trainService.GetTrain(id);
            if (result is null)
                return NotFound("Train not found. ");
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult<List<TrainDetailsModel>>> CreateTrain(CreateTrainModel createTrainModel)
        {
            var result = await _trainService.CreateTrain(createTrainModel);
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<List<TrainDetailsModel>>> UpdateTrain(int id, UpdateTrainModel updateTrainModel)
        {
            var result = await _trainService.UpdateTrain(id, updateTrainModel);
            if (result is null)
                return NotFound("Train not found. ");
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TrainDetailsModel>>> DeleteTrain(int id)
        {
            var result = await _trainService.DeleteTrain(id);
            if (result is null)
                return NotFound("Train not found. ");
            return Ok(result);
        }
        
    }
}
