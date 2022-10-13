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
        public ActionResult<IEnumerable<BikeDto>> GetAll()
        {
            var bikesDtos = _bikeService.GetAll();
            
            return Ok(bikesDtos);
        }
        
        [HttpPost]
        public ActionResult CreateBike([FromBody] CreateBikeDto dto)
        {
          
            var id = _bikeService.Create(dto);

            return Created($"api/bike/{id}", id);
        }
        
    }
}
