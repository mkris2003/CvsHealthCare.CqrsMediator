using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CvsHealthCare.CqrsMediator.Domain.Entities;

namespace CvsHealthCare.CqrsMediator.Application.Employees.Queries.GetEmployeeDetails
{
  public  class EmployeeDetailModel
    {
        public int EmpNo { get; set; }
        public string EmpFirstName { get; set; } = string.Empty;
        public string EmpLastName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        public DateTime DateofJoined { get; set; } = DateTime.MinValue;

        public static Expression<Func<Employee, EmployeeDetailModel>> Projection
        {
            get
            {
                return employee => new EmployeeDetailModel
                {
                    EmpNo = employee.EmpNo,
                    EmpFirstName = employee.EmpFirstName,
                    EmpLastName = employee.EmpLastName,
                    City = employee.City,
                    State = employee.State,
                    Country = employee.Country,
                    BeginDate = employee.BeginDate,
                    EndDate = employee.EndDate,
                    DateofJoined = employee.DateofJoined
                };
            }
        }
        public static EmployeeDetailModel Create(Employee employee)
        {
            return Projection.Compile().Invoke(employee);
        }
    }
}
