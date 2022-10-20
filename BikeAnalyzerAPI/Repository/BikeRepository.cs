using BikeAnalyzerAPI.Entities;

namespace BikeAnalyzerAPI.Repository
{
    public class BikeRepository : IBikeRepository
    {
        private readonly BikeDbContext _dbContext;

        public BikeRepository(BikeDbContext context)
        {
            context = _dbContext;
        }
        public Bike GetById(int id)
        {
            var bike = _dbContext
                .Bikes
                .FirstOrDefault(r => r.Id == id);
            return bike;
        }
    }

}
