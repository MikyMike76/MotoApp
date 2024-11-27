using MotoApp.Entities;
using MotoApp.Repositories;
using System.Linq;

namespace MotoApp.DataProvider
{
    public class CarsProvider : ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;
        public CarsProvider(IRepository<Car> carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public string AnonymousClass()
        {
            throw new NotImplementedException();
        }

        public List<Car> FilterCars(decimal minPrice)
        {
            throw new NotImplementedException();
        }

        public decimal GetMinimumPriceOfAllCars()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetSpicificColumns()
        {
            throw new NotImplementedException();
        }

        public List<string> GetUniqueCarColors()
        {
            var cars = _carsRepository;
            var colors = cars.Select (x => x.CarColor).Distinct();
        }
    }
}
