using MotoApp;
using MotoApp.Repositories;
using MotoApp.Entities;

var employeeRepository = new GenericRepository<Employee>();
employeeRepository.Add(new Employee { FirstName = "Adam" });
employeeRepository.Add(new Employee { FirstName = "Piotr" });
employeeRepository.Add(new Employee { FirstName = "Zuzia" });
employeeRepository.Save();