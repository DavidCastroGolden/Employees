using DAL.Repositories.Interfaces;
using Salary.ViewModel.Employees;
using Salary2.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test.Salary
{
    public class EmployeesTest
    {
        private readonly ISalaryRepository repository;

        [Fact]
        public void GetAllEmployeesInformation()
        {
            var employeeController = new EmployeeControllerFake(repository);

            //employeeController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = employeeController.GetAllEmployees();

            var viewResult = Assert.IsType<EmployeeDto>(actionResult);
            Assert.IsAssignableFrom<EmployeeDto>(viewResult);

        }
    }
}
