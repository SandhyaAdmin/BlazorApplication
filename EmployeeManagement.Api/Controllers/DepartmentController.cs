using EmployeeManagement.Api.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public  DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                return Ok(await departmentRepository.GetDepartments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retreiving department data from database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            try
            {
                var department = await departmentRepository.GetDepartment(id);
                if(department == null)
                {
                    return NotFound();
                }
                return Ok(department);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retreiving department data from database");
            }
        }

    }
}
