using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly string filePath = "employees.json";

        // GET: All Employees
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = LoadEmployees();
                return Ok(employees);
            }
            catch (System.Exception ex)
            {
                LogError(ex.Message);
                return StatusCode(500, "Error loading employees  ..");
            }
        }

        //  GET: Search by ID
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employees = LoadEmployees();
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound("Employee not found.");
            return Ok(emp);
        }

        //  POST: Add Employee
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee emp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           
        
            if (emp == null || string.IsNullOrWhiteSpace(emp.Name) || emp.Salary <= 0)
                return BadRequest("Invalid employee data.");

            if (ContainsMaliciousChars(emp.Name) || ContainsMaliciousChars(emp.Department))
                return BadRequest("Invalid characters in input.");

            var employees = LoadEmployees();
            if (employees.Any(e => e.Id == emp.Id))
                return Conflict("Employee ID already exists.");

            employees.Add(emp);
            SaveEmployees(employees);
            return Ok("Employee added successfully." );

        }

        //  PUT: Update Employee
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmp)
        {
            var employees = LoadEmployees();
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound("Employee not found.");

            emp.Name = updatedEmp.Name;
            emp.Salary = updatedEmp.Salary;
            emp.Department = updatedEmp.Department;

            SaveEmployees(employees);
            return Ok("Employee updated successfully.");
        }

        //  DELETE: Remove Employee
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employees = LoadEmployees();
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound("Employee not found.");

            employees.Remove(emp);
            SaveEmployees(employees);
            return Ok("Employee deleted successfully.");
        }

        // Helper Methods
        //load the employees
        private List<Employee> LoadEmployees()
        {
            if (!System.IO.File.Exists(filePath)) return new List<Employee>();

            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Length > 5 * 1024 * 1024) throw new System.Exception("File too large.");

            var json = System.IO.File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Employee>>(json) ?? new List<Employee>();
        }
        // save employees    
        private void SaveEmployees(List<Employee> employees)
        {
            var json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);
        }

        private bool ContainsMaliciousChars(string input)
        {
            return input.Contains("<") || input.Contains(">") || input.Contains(";") || input.Contains("--");
        }

        private void LogError(string message)
        {
            System.IO.File.AppendAllText("logs.txt", $"{System.DateTime.Now}: {message}\n");
        }
    }
}