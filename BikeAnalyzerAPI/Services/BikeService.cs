using AutoMapper;
using BikeAnalyzerAPI.Entities;
using BikeAnalyzerAPI.Exceptions;
using BikeAnalyzerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BikeAnalyzerAPI.Services
{
    public interface IBikeService
    {
        BikeDto GetById(int id);
        double? Create(CreateBikeDto dto);
        PagedResult<BikeDto> GetAll(BikeQuery query);
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

        public BikeDto GetById(int id)
        {
            var bike = _dbContext
                .Bikes
                .FirstOrDefault(r => r.Id == id);
            if (bike is null) return null;

            var result = _mapper.Map<BikeDto>(bike);
            return result;
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

        public PagedResult<BikeDto> GetAll(BikeQuery query)
        {
            var baseQuery = _dbContext
                .Bikes
                .Where(r => query.SearchPhrase == null || (r.Model.ToLower().Contains(query.SearchPhrase) || r.Brand.ToLower().Contains(query.SearchPhrase)));

            if(!string.IsNullOrEmpty(query.SortBy))
            {
                
                var columnsSelector = new Dictionary<string, Expression<Func<Bike, object>>>
                {
                    { nameof(Bike.Brand), r=>r.Brand },
                    { nameof(Bike.Model), r=>r.Model },
                    { nameof(Bike.GeneralBikeRate), r=>r.GeneralBikeRate },
                };
                var selectedColumn = columnsSelector[query.SortBy];
                baseQuery = query.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var bikes = baseQuery
                .Skip(query.PageSize * (query.PageNumber-1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var bikesDtos = _mapper.Map<List<BikeDto>>(bikes);

            var result = new PagedResult<BikeDto>(bikesDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }

        public double? Create(CreateBikeDto dto)
        {
            var bike = _mapper.Map<Bike>(dto);
            double headTubeAngleparametrA = -20;
            double headTubeAngleparametrB = 1400;
            double seatTubeAngleparametrA = 10;
            double seatTubeAngleparametrB = -700;
            double travelFrontWheelparametrA = 5;
            double travelFrontWheelparametrB = -500;
            double travelBackWheelparametrA = 5;
            double travelBackWheelparametrB = -500;
            double innerRimWidthparametrA = 10;
            double innerRimWidthparametrB = -200;
            double tireWidthparametrA = 250;
            double tireWidthparametrB = -500;
            double weigthparametrA = -20;
            double weigthparametrB = 280;

            double rateHeadTubeAngle = (double)(headTubeAngleparametrA * bike.HeadTubeAngle + headTubeAngleparametrB);
            double rateSeatTubeAngle = (double)(seatTubeAngleparametrA * bike.SeatTubeEffectiveAngle + seatTubeAngleparametrB);
            bike.GeneralBikeRate = rateHeadTubeAngle + rateSeatTubeAngle;   

            _dbContext.Bikes.Add(bike);
            _dbContext.SaveChanges();

            return bike.GeneralBikeRate;
            return bike.Id;
        }
    }
}
