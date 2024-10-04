using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotoApp.Entities;

namespace MotoApp.Repositories
{
    public class EmployeeRepository
    {
        private readonly List<Employee> _employee = new();
        public void Add(Employee employee)
        {
            employee.Id = _employee.Count + 1;
            _employee.Add(employee);
        }
        public void Save()
        {
            foreach (var employee in _employee)
            {
                Console.WriteLine(employee);
            }
        }
        public Employee GetById(int id)
        {
            return _employee.Single(item => item.Id == id);
        }

    }
}
