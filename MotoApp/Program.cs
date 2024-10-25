using MotoApp;
using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;
using MotoApp.Repositories.Extensions;

var itemAdded = new ItemAdded(EmployeeAdded); 
var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), itemAdded);
var itemAdded1 = new ItemAdded(BusinessPartnerAdded);
var businessPartnersRepository = new SqlRepository<BusinessPartner>(new MotoAppDbContext(), itemAdded1);

static void EmployeeAdded(object item)
{
    var employee = (Employee)item;
    Console.WriteLine($"{employee.FirstName} added");
}
static void BusinessPartnerAdded(object item)
{
    var employee = (BusinessPartner)item;
Console.WriteLine($"{employee.Name} added");
}
var employees = new[]
{
    new Employee { FirstName = "Adam" },
    new Employee { FirstName = "Adrian" },
    new Employee { FirstName = "Zuzia" },

};
employeeRepository.AddBatch(employees);
var businessPartners = new[]
{
    new BusinessPartner { Name = "Przemek" },
    new BusinessPartner { Name = "Tomek" }
};
businessPartnersRepository.AddBatch(businessPartners);
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