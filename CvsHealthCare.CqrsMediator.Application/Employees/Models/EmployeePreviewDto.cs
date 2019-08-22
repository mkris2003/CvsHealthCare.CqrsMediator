using System;
using System.Linq.Expressions;
using CvsHealthCare.CqrsMediator.Domain.Entities;

namespace CvsHealthCare.CqrsMediator.Application.Employees.Models
{
    public class EmployeePreviewDto
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
        public static Expression<Func<Employee, EmployeePreviewDto>> Projection
        {
            get
            {
                return e => new EmployeePreviewDto
                {
                    EmpNo =e.EmpNo,
                    EmpFirstName = e.EmpFirstName,
                    EmpLastName = e.EmpLastName,
                    City = e.City,
                    State = e.State,
                    Country = e.Country,
                    BeginDate = e.BeginDate,
                    EndDate = e.EndDate,
                    DateofJoined = e.DateofJoined
                   
                };
            }
        }
    }
}
