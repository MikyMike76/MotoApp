using MotoApp.Entities;
using MotoApp.Repositories;
using System.Text;

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
            var cars = _carsRepository.GetAll();
            var list = cars.Select(car => new
            {
                Identifier = car.Id,
                ProductName = car.Name,
                ProductType = car.Type,
            });

            StringBuilder sb = new StringBuilder(2048);
            foreach (var car in list)
            {
                sb.AppendLine($"Product ID: {car.Identifier}");
                sb.AppendLine($"Product Name: {car.ProductName}");
                sb.AppendLine($"Product Size: {car.ProductType}");
            }

            return sb.ToString();
        }

        public decimal GetMinimumPriceOfAllCars()
        {
            var cars = _carsRepository.GetAll();
            return cars.Select(car => car.ListPrice).Min();
        }

        public List<Car> GetSpicificColumns()
        {
            var cars = _carsRepository.GetAll();
            var list = cars.Select(car => new Car
            {
                Id = car.Id,
                Name = car.Name,
                Type = car.Type,
            }).ToList();
            return list;
        }

        public List<string> GetUniqueCarColors()
        {
            var cars = _carsRepository.GetAll();
            var colors = cars.Select(car => car.Color).Distinct().ToList();
            return colors;
        }
    }
}
