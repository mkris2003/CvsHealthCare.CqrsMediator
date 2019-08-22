using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CvsHealthCare.CqrsMediator.Application.Interfaces.Mapping;
using CvsHealthCare.CqrsMediator.Domain.Entities;

namespace CvsHealthCare.CqrsMediator.Application.Employees.Queries.GetEmployeeList
{
    public class EmployeeLookupModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Employee, EmployeeLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.EmpNo))
                .ForMember(cDTO => cDTO.FirstName, opt => opt.MapFrom(c => c.EmpFirstName))
                .ForMember(cDTO => cDTO.LastName, opt => opt.MapFrom(c => c.EmpLastName));
        }
    }
}
