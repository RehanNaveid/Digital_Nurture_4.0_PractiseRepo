using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;

namespace MyFirstWebApi.Controllers
{
    [Authorize(Roles = "POC,Admin")] // ✅ JWT Role-based access
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Alice",
                Salary = 50000,
                Permanent = true,
                Department = new Department { Id = 1, Name = "HR" },
                Skills = new List<Skill>
                {
                    new Skill { Id = 1, Name = "Communication" },
                    new Skill { Id = 2, Name = "Leadership" }
                },
                DateOfBirth = new DateTime(1990, 5, 24)
            },
            new Employee
            {
                Id = 2,
                Name = "Bob",
                Salary = 60000,
                Permanent = false,
                Department = new Department { Id = 2, Name = "Finance" },
                Skills = new List<Skill>
                {
                    new Skill { Id = 3, Name = "Accounting" }
                },
                DateOfBirth = new DateTime(1988, 11, 15)
            }
        };

        // ✅ GET: api/employee/standard — throws exception (for filter testing)
        [HttpGet("standard")]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> GetStandard()
        {
            throw new Exception("Test exception for filter");
        }

        // ✅ GET: api/employee — get all employees
        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(_employees);
        }

        // ✅ POST: api/employee — add new employee
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee emp)
        {
            emp.Id = _employees.Count + 1;
            _employees.Add(emp);
            return CreatedAtAction(nameof(Get), new { id = emp.Id }, emp);
        }

        // ✅ PUT: api/employee — update employee
        [HttpPut]
        public ActionResult<Employee> Put([FromBody] Employee updatedEmp)
        {
            if (updatedEmp.Id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existingEmp = _employees.Find(e => e.Id == updatedEmp.Id);
            if (existingEmp == null)
            {
                return BadRequest("Invalid employee id");
            }

            existingEmp.Name = updatedEmp.Name;
            existingEmp.Salary = updatedEmp.Salary;
            existingEmp.Permanent = updatedEmp.Permanent;
            existingEmp.Department = updatedEmp.Department;
            existingEmp.Skills = updatedEmp.Skills;
            existingEmp.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(existingEmp);
        }

        // ✅ DELETE: api/employee/{id} — delete employee
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var emp = _employees.Find(e => e.Id == id);
            if (emp == null)
            {
                return BadRequest("Invalid employee id");
            }

            _employees.Remove(emp);
            return Ok($"Employee with id {id} deleted successfully.");
        }
    }
}
