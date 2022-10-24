using BikeAnalyzerAPI.Entities;

namespace BikeAnalyzerAPI.Repository
{
    public class BikeRepository : IBikeRepository
    {
        private readonly BikeDbContext _dbContext;

        public BikeRepository(BikeDbContext context)
        {
            _dbContext = context;
        }
        public Bike GetById(int id)
        {
            var bike = _dbContext
                .Bikes
                .FirstOrDefault(r => r.Id == id);
            return bike;
        }
        public Bike Delete(int id)
        {
            var bike = _dbContext
                .Bikes
                .FirstOrDefault(b => b.Id == id);
            return bike;
        }
        public void Create(Bike bike)
        {
            _dbContext.Bikes.Add(bike);
            _dbContext.SaveChanges();
        }
    }

}
