using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp
{
    public class App : IApp
    {
        private readonly IRepository<Employee> _employeeRepository;
        public App(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void Run()
        {
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
            _employeeRepository.Save();
        }
    }
}
