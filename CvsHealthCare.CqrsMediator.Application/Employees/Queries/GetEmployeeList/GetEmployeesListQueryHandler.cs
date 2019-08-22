using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CvsHealthCare.CqrsMediator.Application.Interfaces;
using MediatR;
using static CvsHealthCare.CqrsMediator.Application.ExtensionsCommon.Extensions;
using static CvsHealthCare.CqrsMediator.Application.Employees.EmployeeDatabaseAccess.EmployeeDataAccess;
using CvsHealthCare.CqrsMediator.Domain.Entities;

namespace CvsHealthCare.CqrsMediator.Application.Employees.Queries.GetEmployeeList
{
    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, EmployeeListViewModel>
    {
        private readonly IDbConnectionFactory _context;
        private readonly IMapper _mapper;

        public GetEmployeesListQueryHandler(IDbConnectionFactory context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EmployeeListViewModel> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var datasetEmployeeDetails = await Task.Run(() => EmployeeDetails(new Employee { EmpNo = 100}, cancellationToken));
            var employeeList = datasetEmployeeDetails.Tables[0].DataTableToList<Employee>();
            return new EmployeeListViewModel
            {
               // EmployeeList = employeeList(_mapper.ConfigurationProvider
            };
        }
    }
}
