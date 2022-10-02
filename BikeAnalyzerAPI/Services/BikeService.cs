using AutoMapper;
using BikeAnalyzerAPI.Entities;
using BikeAnalyzerAPI.Exceptions;
using BikeAnalyzerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeAnalyzerAPI.Services
{
    public interface IBikeService
    {
        int Create(CreateBikeDto dto);
        IEnumerable<BikeDto> GetAll();
        void Delete(int id);
    }

    public class BikeService : IBikeService
    {
        private readonly BikeDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BikeService> _logger;

        public BikeService(BikeDbContext dbContext, IMapper mapper, ILogger<BikeService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(int id)
        {
            _logger.LogError($"Bike with id: {id} DELETE action invoked");

            var bike = _dbContext
                .Bikes
                .FirstOrDefault(b => b.Id == id);
            if (bike is null) 
                throw new NotFoundException("Bike not found");

            _dbContext.Bikes.Remove(bike);
            _dbContext.SaveChanges();

        }

        public IEnumerable<BikeDto> GetAll()
        {
            var bikes = _dbContext.Bikes.ToList();

            var bikesDtos = _mapper.Map<List<BikeDto>>(bikes);

            return bikesDtos;
        }

        public int Create(CreateBikeDto dto)
        {
            var bike = _mapper.Map<Bike>(dto);
            _dbContext.Bikes.Add(bike);
            _dbContext.SaveChanges();

            return bike.Id;
        }
    }
}
