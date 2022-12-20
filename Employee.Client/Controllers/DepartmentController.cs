using Employee.Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Client.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController: ControllerBase
    {
        private readonly IDepartment depatrmentRepository;

        public DepartmentController(IDepartment depatrmentRepository)
        {
            this.depatrmentRepository = depatrmentRepository;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var dept = (this.depatrmentRepository.GetDepartments());
            if (dept == null)
            {
                return BadRequest();
            }
            return Ok(dept);
        }

        [HttpGet("active")]
        public IActionResult GetActiveDepartments()
        {
            var dept = (this.depatrmentRepository.GetActiveDepartments());
            if (dept == null)
            {
                return BadRequest();
            }
            return Ok(dept);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentDetailById(int id)
        {
            var dept = (this.depatrmentRepository.GetDepartmentDetailById(id));
            if (dept == null)
            {
                return BadRequest();
            }
            return Ok(dept);
        }

        [HttpGet("{id}/Employees")]
        public IActionResult GetAllEmployeeByDepartment(int id)
        {
            var dept = (this.depatrmentRepository.GetAllEmployeeByDepartment(id));
            if (dept == null)
            {
                return BadRequest();
            }
            return Ok(dept);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var dept = (this.depatrmentRepository.DeleteDepartment(id));
            if (dept == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
