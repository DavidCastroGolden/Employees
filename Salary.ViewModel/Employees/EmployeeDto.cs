using System;
using System.Collections.Generic;
using System.Text;

namespace Salary.ViewModel.Employees
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string contractTypeName { get; set; }

        public string roleName { get; set; }

        public string roleDescription { get; set; }

        public decimal hourlySalary { get; set; }

        public decimal hourlyToAnualSalary => 120 * hourlySalary * 12;

        public decimal monthlySalary { get; set; }

        public decimal montlyToAnualSalary => monthlySalary * 12;

    }
}
