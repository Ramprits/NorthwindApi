using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthwind.Entities;

namespace WebApplicationNorthwind.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(Guid employeeGuid);
        void AddEmployee(Employee employee);
        void DeleteAuthor(Employee employee);
        void UpdateAuthor(Employee employee);
        bool AuthorExists(Guid employeeGuid);
        bool Save();
    }
}
