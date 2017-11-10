using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNorthwind.Model;
using WebApplicationNorthwind.Services;


namespace WebApplicationNorthwind.Controllers
{
    [Route("api/Employees"), EnableCors("AllowAny")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _repo;

        public EmployeesController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employeesFromRepo = _repo.GetEmployees();
            var employee = Mapper.Map<IEnumerable<EmployeeVm>>(employeesFromRepo);
            return Ok(employee);
        }

        [HttpGet("{employeeGuid}")]
        public IActionResult Get(Guid employeeGuid)
        {
            var employeeFromRepo = _repo.GetEmployee(employeeGuid);
            var employee = Mapper.Map<EmployeeVm>(employeeFromRepo);
            return Ok(employee);
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
