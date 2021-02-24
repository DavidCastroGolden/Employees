using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Salary.ViewModel.Employees;

namespace Salary2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ISalaryRepository _repository;

        public EmployeeController(ISalaryRepository repository)
        {
            _repository = repository;

        }

        public ActionResult<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            var employees = _repository.GetAllEmployees();

            if (employees == null)
                return NotFound();

            return Ok(employees);

        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployeeById(int Id)
        {
            //using the same repository but adding a where clause at the end of this statement.
            var employee = _repository.GetAllEmployees().Where(x => x.Id == Id);

            if (employee == null)
                return NotFound();

            return Ok(employee);

        }
    }
}
