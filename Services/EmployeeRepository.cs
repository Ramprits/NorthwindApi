using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationNorthwind.Context;
using WebApplicationNorthwind.Entities;

namespace WebApplicationNorthwind.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly NorthWindDbContext _ctx;

        public EmployeeRepository(NorthWindDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _ctx.Employees.OrderByDescending(x => x.CreatedDate).ToList();
        }

        public Employee GetEmployee(Guid employeeGuid)
        {
            return _ctx.Employees.FirstOrDefault(x => x.EmployeeGuid == employeeGuid);
        }

        public void AddEmployee(Employee employee)
        {
            employee.EmployeeGuid = Guid.NewGuid();
            _ctx.Add(employee);
        }

        public void DeleteAuthor(Employee employee)
        {
            _ctx.Remove(employee);
        }

        public void UpdateAuthor(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool EmployeeExists(Guid employeeGuid)
        {
            return _ctx.Employees.Any(x => x.EmployeeGuid == employeeGuid);
        }

        public bool Save()
        {
            return (_ctx.SaveChanges() >= 0);
        }
    }
}
