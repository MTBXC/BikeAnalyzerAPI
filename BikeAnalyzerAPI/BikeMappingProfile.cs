using AutoMapper;
using BikeAnalyzerAPI.Entities;
using BikeAnalyzerAPI.Models;

namespace BikeAnalyzerAPI
{
    public class BikeMappingProfile : Profile
    {
        public BikeMappingProfile()
        {
            CreateMap<Bike, BikeDto>();

            CreateMap<CreateBikeDto, Bike>();
        }
    }
}
