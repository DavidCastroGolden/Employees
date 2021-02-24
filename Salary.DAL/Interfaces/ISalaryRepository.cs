using Salary.ViewModel.Employees;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DAL.Repositories.Interfaces
{
    public interface ISalaryRepository
    {
        IEnumerable<EmployeeDto> GetAllEmployees();
    }
}
