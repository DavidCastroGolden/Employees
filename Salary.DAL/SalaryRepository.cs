using BusinessLogic.Helper;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Nancy.Json;
using Salary.ViewModel.Employees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace DAL.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {

        private readonly string externalUrl;
        public SalaryRepository(IConfiguration configuration)
        {
            externalUrl = configuration.GetSection("ExternalAndNotSecureEmployeesAPI").Value;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {

            ExternalAPIConsumer externalAPIConsumer = new ExternalAPIConsumer();

            var response = externalAPIConsumer.GetDataFromExternalAPI(externalUrl);

            if (!string.IsNullOrWhiteSpace(response))
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                List<EmployeeDto> employeesList = js.Deserialize<List<EmployeeDto>>(response);

                return employeesList;
            }

            return new List<EmployeeDto>();


        }
    }
}
