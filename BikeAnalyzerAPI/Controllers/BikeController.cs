using AutoMapper;
using BikeAnalyzerAPI.Entities;
using BikeAnalyzerAPI.Models;
using BikeAnalyzerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeAnalyzerAPI.Controllers
{
    [Route("api/bike")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly IBikeService _bikeService;

        public BikeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _bikeService.Delete(id);
          
            return NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<BikeDto>> GetAll([FromQuery]BikeQuery query)
        {
            var bikesDtos = _bikeService.GetAll(query);
            
            return Ok(bikesDtos);
        }
        [HttpGet("{id}")]
        public ActionResult<BikeDto> Get([FromRoute] int id)
        {
            var bike = _bikeService.GetById(id);
            if (bike is null)
            {
                return NotFound();
            }
            return Ok(bike);
        }
        
        [HttpPost]
        public ActionResult CreateBike([FromBody] CreateBikeDto dto)
        {
            var id = _bikeService.Create(dto);

            return Created($"api/bike/{id}", $"GeneralBikeRate: {id}, Id of bike: {id}");
        }
        
    }
}
