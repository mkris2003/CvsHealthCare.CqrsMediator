using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CvsHealthCare.CqrsMediator.Application.Exceptions;
using CvsHealthCare.CqrsMediator.Application.Interfaces;
using CvsHealthCare.CqrsMediator.Domain.Entities;
using MediatR;
using static CvsHealthCare.CqrsMediator.Application.Employees.EmployeeDatabaseAccess.EmployeeDataAccess;
using static CvsHealthCare.CqrsMediator.Application.ExtensionsCommon.Extensions;
namespace CvsHealthCare.CqrsMediator.Application.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDetailModel>
    {
        private readonly IDbConnectionFactory _context;

        public GetEmployeeDetailQueryHandler(IDbConnectionFactory context)
        {
            _context = context;
        }
        public async Task<EmployeeDetailModel> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
        {
            var datasetEmployeeDetails = await Task.Run(() => EmployeeDetails(new Employee { EmpNo = request.EmpNo }, cancellationToken));
            var employeeList = datasetEmployeeDetails.Tables[0].DataTableToList<Employee>();
            if (employeeList.Count == 0)
            {
                throw new NotFoundException(nameof(Employee), request.EmpNo);
            }
            var entity = employeeList[0];
            return EmployeeDetailModel.Create(entity);
        }
    }
}
