using BikeAnalyzerAPI.Entities;

namespace BikeAnalyzerAPI
{
    public class BikeSeeder
    {
        private readonly BikeDbContext _dbContext;
        public BikeSeeder(BikeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {

            if(_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Bikes.Any())
                {
                    var bikes = GetBikes();
                        _dbContext.Bikes.AddRange(bikes);
                        _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name="Admin"
                }
            };
            return roles;
        }
        private IEnumerable<Bike> GetBikes()
        {
            var bikes = new List<Bike>()
            { 
                new Bike()
                {
                    Brand = "Scott",
                    Model = "Spark RC World Cup Evo",
                    YearOfProduction = 2022,
                    HeadTubeAngle = 67.3,
                    SeatTubeEffectiveAngle = 74,
                    TravelFrontWheel = 120,
                    TravelBackWheel = 120,
                    InnerRimWidth = 30,
                    TireWidth = 2.4,
                    Weigth = 10.3
                },
                new Bike()
                {
                    Brand = "Scott",
                    Model = "Spark RC World Cup",
                    YearOfProduction = 2022,
                    HeadTubeAngle = 67.3,
                    SeatTubeEffectiveAngle = 74,
                    TravelFrontWheel = 120,
                    TravelBackWheel = 120,
                    InnerRimWidth = 30,
                    TireWidth = 2.4,
                    Weigth = 10.7
                }
                



            };
            return bikes;
        }

    }
}
