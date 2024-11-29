using MotoApp.DataProvider;
using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp
{
    public class App : IApp
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Car> _carsRepository;
        private readonly ICarsProvider _carsProvider;
        public App(
            IRepository<Employee> employeesRepository, 
            IRepository<Car> carsRepository,
            ICarsProvider carsProvider)
        {
            _employeeRepository = employeesRepository;
            _carsRepository = carsRepository;
            _carsProvider = carsProvider;
        }
        public void Run()
        {
            // adding
            Console.WriteLine("I'm here in Run() method");
            var employees = new[]
            {
                new Employee {FirstName = "Adam"},
                new Employee {FirstName = "Zuzia"},
                new Employee {FirstName = "Piotr"}
            };
            foreach (var employee in employees)
            {
                _employeeRepository.Add(employee);
            }
            //_employeeRepository.Save();

            // reading
            var items = _employeeRepository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            // cars
            var cars = GenerateSampleCars();
            foreach (var car in cars)
            {
                _carsRepository.Add(car);
            }

            foreach (var car in _carsProvider.GetUniqueCarColors())
            {
                Console.WriteLine(car);
            }
            foreach(var car in _carsProvider.OrderByColorAndName())
            {
                Console.WriteLine(car);
            }
        }
        public static List<Car> GenerateSampleCars()
        {
            return new List<Car>
        {
            new Car
            {
                Id = 831,
                Name = "Car22",
                Color = "red",
                StandardCost = 1234m,
                ListPrice = 2345m,
                Type = "52"
            },
            new Car
            {
                Id = 1200,
                Name = "Car33",
                Color = "red",
                StandardCost = 900m,
                ListPrice = 1800m,
                Type = "52"
            },
            new Car
            {
                Id = 1305,
                Name = "Car44",
                Color = "green",
                StandardCost = 2030m,
                ListPrice = 4500m,
                Type = "52"
            },
            new Car
            {
                Id = 222,
                Name = "Car21",
                Color = "green",
                StandardCost = 443m,
                ListPrice = 786m,
                Type = "33"
            },
            new Car
            {
                Id = 223,
                Name = "Car23",
                Color = "black",
                StandardCost = 654m,
                ListPrice = 1365m,
                Type = "11"
            },
            new Car
            {
                Id = 135,
                Name = "Adelo",
                Color = "blue",
                StandardCost = 5000m,
                ListPrice = 1000m,
                Type = "23"
            }
        };
        }
    }
}
