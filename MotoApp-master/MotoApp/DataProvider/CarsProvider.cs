using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp.DataProvider
{
    public class CarsProvider : ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;
        public CarsProvider(IRepository<Car> carsRepository)
        {
            _carsRepository = carsRepository;
        }
        public List<Car> FilterCars(decimal minPrice)
        {
            throw new NotImplementedException();
        }

        public decimal GetMinimumPriceOfAllCars()
        {
            throw new NotImplementedException();
        }

        public List<string> GetUniqueCarColors()
        {
            throw new NotImplementedException();
        }
    }
}
