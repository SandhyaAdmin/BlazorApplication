using EmployeeManagement.Api.DataAccessLayer;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var searchResult = await employeeRepository.Search(name, gender);
                if (searchResult.Any())
                {
                    return Ok(searchResult);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error while searching data from Database");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error while retrieving data from Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {               
                var employee = await employeeRepository.GetEmployee(id);
                if(employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retriving data from database");
                
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    return BadRequest();
                }
                var empExistedWithEmail = await employeeRepository.GetEmployeeByEmail(employee.Email);
                if(empExistedWithEmail != null)
                {
                    ModelState.AddModelError("email", "Employee Email already in use");
                    return BadRequest(ModelState);
                }
                var createdEmployee = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error occured while adding Employee data into database");
            }

        }

        [HttpPut()]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                var employeeToUpdate = await employeeRepository.GetEmployee(employee.EmployeeId);
                if(employeeToUpdate == null)
                {
                    return NotFound($"Employee with Id = {employee.EmployeeId} not found");
                }
                return Ok(await employeeRepository.UpdateEmployee(employee));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error occured while updating Employee data into database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {               
                var employeeToDelete = await employeeRepository.GetEmployee(id);
                if(employeeToDelete == null)
                {
                    return NotFound($"Employee with id = {id} not found");
                }
                return Ok(await employeeRepository.DeleteEmployee(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error occured while inserting data in database");
            }
        }

    }
}
