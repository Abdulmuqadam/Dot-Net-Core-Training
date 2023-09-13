using CRUDWithStoreProcedure.Interfaces;
using CRUDWithStoreProcedure.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithStoreProcedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository _repository;

        public EmployeesController(EmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _repository.GetEmployees();
            return Ok(employees);
        }


        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            _repository.CreateEmployee(employee);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            if ( id != employee.EmployeeID )
            {
                return BadRequest();
            }
            else
            {
                _repository.UpdateEmployee(employee);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _repository.DeleteEmployee(id);
            return Ok();
        }
    }
}
