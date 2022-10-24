using BikeAnalyzerAPI.Entities;

namespace BikeAnalyzerAPI.Repository
{
    public interface IBikeRepository
    {
        Bike GetById(int id);
        Bike Delete(int id);
        void Create(Bike bike);
    }
}