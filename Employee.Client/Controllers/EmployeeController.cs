using Employee.Business.Interface;
using Employee.Business.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Client.Controllers
{
    [Route("api/employee")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employeeRepository;

        public EmployeeController(IEmployee employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeDetailById(int id)
        {
            var emp = (this.employeeRepository.GetEmployeeDetailById(id));
            if (emp == null)
            {
                return BadRequest();
            }
            return Ok(emp);
        }

        [HttpGet()]
        public IActionResult GetActiveEmployee()
        {
            var emp = (this.employeeRepository.GetActiveEmployee());
            if (emp == null)
            {
                return BadRequest();
            }
            return Ok(emp);
        }

        [HttpPut()]
        public IActionResult UpdateEmployeeDetail(Employees employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            var emp = (this.employeeRepository.UpdateEmployeeDetail(employee));
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult CreateEmployeeDetail(Employees employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            var emp = (this.employeeRepository.CreateEmployeeDetail(employee));
            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = (this.employeeRepository.DeleteEmployee(id));
            if (emp == null)
            {
                return BadRequest();
            }
            return Ok(emp);
        }

        //public bool EmployeeDetailExists(int id)
        //{
        //    try
        //    {
        //        return Ok(this.employeeRepository.EmployeeDetailExists(id));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
