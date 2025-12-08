using BCTECHAPI.Core.Interfaces;
using BCTECHAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BCTECHAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee_service;

        public EmployeeController(IEmployeeService _employeeservice)
        {
            this._employee_service = _employeeservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employee_service.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employee_service.GetByIdAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            var newEmployee = await _employee_service.AddAsync(employee);
            return CreatedAtAction(nameof(GetById), new {id = newEmployee.Id}, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if(id != employee.Id)
            {
                return BadRequest();
            }

            var updated = await _employee_service.UpdateAsync(employee);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employee_service.DeleteAsync(id);
            return NoContent();
        }

    }
}