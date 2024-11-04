using MotoApp;
using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;
using MotoApp.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
employeeRepository.itemAdded += OnItemAdded;
AddEmployees(employeeRepository);
var businessPartnersRepository = new SqlRepository<BusinessPartner>(new MotoAppDbContext(), BusinessPartnerAdded);
AddBusinessPartner(businessPartnersRepository);

static void OnItemAdded(object? sender, Employee e)
{
    Console.WriteLine($"Employee {e.FirstName} added from {sender?.GetType().Name}");
}
static void EmployeeAdded(Employee item)
{
    Console.WriteLine($"{item.FirstName} added");
}
static void BusinessPartnerAdded(BusinessPartner item)
{
    Console.WriteLine($"{item.Name} added");
}

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    var employees = new[]
    {
    new Employee { FirstName = "Adam" },
    new Employee { FirstName = "Adrian" },
    new Employee { FirstName = "Zuzia" },

    };
    employeeRepository.AddBatch(employees);
}
static void AddBusinessPartner(IRepository<BusinessPartner> businessPartnersRepository)
{
    var businessPartners = new[]
    {
    new BusinessPartner { Name = "Przemek" },
    new BusinessPartner { Name = "Tomek" }
    };
    businessPartnersRepository.AddBatch(businessPartners);
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
WriteAllToConsole(employeeRepository);
WriteAllToConsole(businessPartnersRepository);