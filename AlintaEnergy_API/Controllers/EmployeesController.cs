using AlintaEnergy_API.ApplicationLayer;
using AlintaEnergy_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlintaEnergy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }
        
        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try
            {
                return Ok(await _employeeService.GetEmployees().ConfigureAwait(true));
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
            }
            return null;
        }

        // GET: api/Employees/9
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee(string id)
        {
            try
            {
                return Ok(await _employeeService.GetEmployee(id).ConfigureAwait(true));
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            return null;
        }

        // GET: api/Employees//firstname/name
        [HttpGet("/firstname/{firstName}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByFirstName(string firstName)
        {
            try
            {
                var employees = await _employeeService.GetEmployeesByFirstName(firstName).ConfigureAwait(true);

                if (employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            return null;
        }

        // GET: api/Employees//lastname/name
        [HttpGet("/lastname/{lastname}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByLastName(string firstName)
        {
            try
            {
                var employees = await _employeeService.GetEmployeesByLastName(firstName).ConfigureAwait(true);

                if (employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            return null;
        }

        // PUT: api/Employees/9
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEmployee(string id, Employee employee)
        {
            try
            {
                if (id != employee.Id)
                {
                    return BadRequest();
                }
                var is_Employee = await _employeeService.GetEmployee(id).ConfigureAwait(true);
                if (is_Employee == null)
                {
                    return NotFound();
                }
                await _employeeService.UpdateEmployee(employee).ConfigureAwait(true);

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            return null;
        }

        // POST: api/Employees        
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            try
            {
                await _employeeService.InsertEmployee(employee).ConfigureAwait(true);

                return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            return null;
        }

        // DELETE: api/Employees/9
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(string id)
        {
            try
            {
                var is_Employee = await _employeeService.GetEmployee(id).ConfigureAwait(true);
                if (is_Employee == null)
                {
                    return NotFound();
                }

                await _employeeService.DeleteEmployee(is_Employee).ConfigureAwait(true);

                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            return null;
        }
    }
}
