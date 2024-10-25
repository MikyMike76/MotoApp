using MotoApp;
using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddManagers(employeeRepository);
WriteAllToConsole(employeeRepository);

static void AddBatch<T>(IRepository<T> repository, T[] items)
    where T : class, IEntity
{
    foreach (var item in items)
    {
        repository.Add(item);
    }
    repository.Save();
}
var employees = new[]
{
    new Employee { FirstName = "Adam" },
    new Employee { FirstName = "Adam" },
    new Employee { FirstName = "Adam" },

};
AddBatch<Employee>(employeeRepository, employees);
static void AddManagers(IWriteRepository<Manager> menagerRepository)
{
    menagerRepository.Add(new Manager { FirstName = "Przemek" });
    menagerRepository.Add(new Manager { FirstName = "Tomek" });
    menagerRepository.Save();
}
static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}