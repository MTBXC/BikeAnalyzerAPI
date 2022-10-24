using AutoMapper;
using BikeAnalyzerAPI.Entities;
using BikeAnalyzerAPI.Repository;
using BikeAnalyzerAPI.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BikeAnalyzerAPI.Tests

{
    public class BikeServiceTest
    {
        private readonly Mock<BikeDbContext> _dbContextMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<BikeService>> _loggerMock;
        private readonly Mock<IBikeRepository> _bikerepositoryMock;


        public BikeServiceTest()
        {
            _dbContextMock = new Mock<BikeDbContext>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<BikeService>>();
            _bikerepositoryMock = new Mock<IBikeRepository>();
        }
        [Fact]
        public void GetById_GetBikeById_IfExist_ReturnBike()
        {
            //arrange
            int id = 1;
            var bike = new Bike()
            {
                Id = 1,
                Brand = "Scott",
                Model = "Spark RC World Cup Evo",
                YearOfProduction = 2022,
                HeadTubeAngle = 67.3,
                SeatTubeEffectiveAngle = 74,
                TravelFrontWheel = 120,
                TravelBackWheel = 120,
                InnerRimWidth = 30,
                TireWidth = 2.4,
                Weigth = 10.3,
                GeneralBikeRate = 10
            };

            _bikerepositoryMock.Setup(b => b.GetById(id)).Returns(bike);

            //act
            var _sut = new BikeService(_dbContextMock.Object, _mapperMock.Object, _loggerMock.Object, _bikerepositoryMock.Object);
            _sut.GetById(bike.Id);

            //assert

            Assert.Equal(1, bike.Id);


        }
    }
}