using AlintaEnergy_API.ApplicationLayer;
using AlintaEnergy_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlintaEnergy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(await _employeeService.GetEmployees());
        }

        // GET: api/Employees/9
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee(string id)
        {
            return Ok(await _employeeService.GetEmployee(id));
        }

        // GET: api/Employees//firstname/name
        [HttpGet("/firstname/{firstName}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByFirstName(string firstName)
        {
            var employees = await _employeeService.GetEmployeesByFirstName(firstName);

            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        // GET: api/Employees//lastname/name
        [HttpGet("/lastname/{lastname}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByLastName(string firstName)
        {
            var employees = await _employeeService.GetEmployeesByLastName(firstName);

            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        // PUT: api/Employees/9
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEmployee(string id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            var is_Employee = await _employeeService.GetEmployee(id);
            if (is_Employee ==  null)
            {
                return NotFound();
            }
            await _employeeService.UpdateEmployee(employee);

            return NoContent();
        }

        // POST: api/Employees        
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _employeeService.InsertEmployee(employee);

            return CreatedAtAction(nameof(GetEmployee), new{ id = employee.Id}, employee);
        }

        // DELETE: api/Employees/9
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(string id)
        {
            var is_Employee = await _employeeService.GetEmployee(id);
            if (is_Employee == null)
            {
                return NotFound();
            }

           await _employeeService.DeleteEmployee(is_Employee);

            return Ok();
        }
    }
}
