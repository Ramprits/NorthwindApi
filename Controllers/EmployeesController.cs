using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationNorthwind.Entities;
using WebApplicationNorthwind.Model;
using WebApplicationNorthwind.Services;


namespace WebApplicationNorthwind.Controllers
{
    [Route("api/Employees"), EnableCors("AllowAny")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _repo;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeRepository repo, ILogger<EmployeesController> loger)
        {
            _repo = repo;
            _logger = loger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employeesFromRepo = _repo.GetEmployees();
            var employee = Mapper.Map<IEnumerable<EmployeeVm>>(employeesFromRepo);
            _logger.LogInformation("Sucessfull loaded !");
            return Ok(employee);
        }

        [HttpGet("{employeeGuid}", Name = "getEmployee")]
        public IActionResult Get(Guid employeeGuid)
        {
            if (_repo.EmployeeExists(employeeGuid))
            {
                return NotFound();
            }
            var employeeFromRepo = _repo.GetEmployee(employeeGuid);
            var employee = Mapper.Map<EmployeeVm>(employeeFromRepo);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody]CreateEmployee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var employeeEntity = Mapper.Map<Employee>(employee);
            _repo.AddEmployee(employeeEntity);
            if (!_repo.Save())
            {
                throw new Exception("Creating an author failed on save.");
            }
            var employeeToReturn = _repo.GetEmployee(employeeEntity.EmployeeGuid);
            return Created("getEmployee", new { employeeGuid = employeeToReturn.EmployeeGuid });

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
