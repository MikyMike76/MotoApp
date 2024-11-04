using MotoApp;
using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;
using MotoApp.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
employeeRepository.itemAdded += OnEmployeeAdded;
AddEmployees(employeeRepository);
var businessPartnersRepository = new SqlRepository<BusinessPartner>(new MotoAppDbContext(), BusinessPartnerAdded);
businessPartnersRepository.itemAdded += OnBusinessPartnerAdded;
AddBusinessPartner(businessPartnersRepository);

static void OnEmployeeAdded(object? sender, Employee e)
{
    Console.WriteLine($"Employee {e.FirstName} added from {sender?.GetType()}");
}
static void OnBusinessPartnerAdded(object? sender, BusinessPartner e)
{
    Console.WriteLine($"BusinessPartner {e.Name} added from {sender?.GetType()}");
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