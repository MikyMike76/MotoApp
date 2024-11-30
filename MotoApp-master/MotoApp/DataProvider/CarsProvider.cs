using MotoApp.DataProvider.Extensions;
using MotoApp.Entities;
using MotoApp.Repositories;
using System;
using System.Drawing;
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
        public List<string> GetUniqueCarColors()
        {
            var cars = _carsRepository.GetAll();
            var colors = cars.Select(car => car.Color).Distinct().ToList();
            return colors;
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
        public List<Car> OrderByName() // sort ascending by default
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderBy(x => x.Name).ToList();
        }
        public List<Car> OrderByNameDescending()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderByDescending(x => x.Name).ToList();
        }
        public List<Car> OrderByColorAndName()  //firstly orders ascending by color, then if colors are equal, orders these with equal colors by name
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x=>x.Color)
                .ThenBy(x=>x.Name)
                .ToList();
        }
        public List<Car> OrderByColorAndNameDesc()
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderByDescending(x => x.Color)
                .ThenByDescending(x => x.Name)
                .ToList();
        }
        public List<Car> WhereColorIs(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.ByColor(color).ToList();  // sama metoda LINQ siedzi w DataProvider->Extensions->CarHelper
        }

        public List<Car> WhereStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(x => x.Name.StartsWith(prefix)).ToList();
        }

        public List<Car> WhereStartsWithAndGreaterThan(string prefix, decimal cost)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(x => x.Name.StartsWith(prefix) && x.StandardCost > cost).ToList();
        }
        public Car FirstByColor(string color) // jeśli lista nie zawiera podanego koloru, poleci Exception
        {
            var cars = _carsRepository.GetAll();
            return cars.First(x => x.Color == color);
        }

        public Car? FirstOrDefaultByColor(string color) // na wypadek jakby lista nie zawierała żadnego samochodu od danym kolorze, aby nie poleciał Exception. 
        {                                               // defaultem jest tu null
            var cars = _carsRepository.GetAll();
            return cars.FirstOrDefault(x => x.Color == color);
        }

        public Car FirstOrDefaultByColorWithDefault(string color) // tu możemy określić, co jest defaultem zamiast null
        {
            var cars = _carsRepository.GetAll();
            return cars
                .FirstOrDefault(
                x => x.Color == color, 
                new Car { Id = -1, Color = "NOT FOUND" }); 
        }
        public Car LastByColor(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.Last(x => x.Color == color);
        }
        public Car SingleById(int id)  // jeśli istnieje więcej takich obiektów niż jeden, poleci Exception, informujący, że takich obiektów jest więcej
        {
            var cars = _carsRepository.GetAll();
            return cars.Single(x => x.Id == id);
        }
        public Car? SingleOrDefaultById(int id)
        {
            var cars = _carsRepository.GetAll();  // jeśli istnieje więcej takich obiektów, dostaniemy null, dlatego przy Car jest znak "?"
            return cars.SingleOrDefault(x => x.Id == id);
        }

        public List<Car> TakeCars(int howMany)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .Take(howMany)
                .ToList();
        }

        public List<Car> TakeCars(Range range)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .Take(range)
                .ToList();
        }

        public List<Car> TakeCarsWhileNameStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .TakeWhile(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        public List<Car> SkipCars(int howMany)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .Skip(howMany)
                .ToList();
        }

        public List<Car> SkipCarsWhileNameStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .SkipWhile(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        public List<string> DistinctAllColors()
        {
            var cars = _carsRepository.GetAll();
            return cars
                .Select(x => x.Color)
                .Distinct()
                .OrderBy(c=>c)
                .ToList();
        }

        public List<Car> DistinctByColors()
        {
            var cars = _carsRepository.GetAll();
            return cars
                .DistinctBy(x => x.Color)
                .OrderBy(c => c.Color)
                .ToList();
        }
        public List<Car[]> ChunkCars(int size)   // tnie jedną tablicę/listę na wiele tablic dwuelementowych
        {                                        // Mając 9-elemtową tablicę i podając "size = 2", dostaniemy 4 tablice po 2 elementy i jedną - 1-elemntową
            var cars = _carsRepository.GetAll(); // Wykorzystuje się do przesyłania/wyświetlania danych paczkami 
            return cars.Chunk(size).ToList();
        }
    }
}
