using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CvsHealthCare.CqrsMediator.Application.Interfaces;
using MediatR;
using static CvsHealthCare.CqrsMediator.Application.Employees.EmployeeDatabaseAccess.EmployeeDataAccess;
namespace CvsHealthCare.CqrsMediator.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IDbConnectionFactory _context;

        public DeleteEmployeeCommandHandler(IDbConnectionFactory context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await DeleteEmployees(request.EmpNo, cancellationToken);
            return Unit.Value;
        }
    }
}
