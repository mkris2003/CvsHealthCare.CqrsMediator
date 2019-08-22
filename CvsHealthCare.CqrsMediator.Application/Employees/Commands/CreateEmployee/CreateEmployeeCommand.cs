using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CvsHealthCare.CqrsMediator.Application.Interfaces;
using CvsHealthCare.CqrsMediator.Domain.Entities;
using MediatR;
using static CvsHealthCare.CqrsMediator.Application.Employees.EmployeeDatabaseAccess.EmployeeDataAccess;
namespace CvsHealthCare.CqrsMediator.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand: IRequest
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

        public class Handler : IRequestHandler<CreateEmployeeCommand, Unit>
        {
            private readonly IDbConnectionFactory _context;
            private readonly IMediator _mediator;

            public Handler(IDbConnectionFactory context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var entity = new Employee
                {
                    EmpNo = request.EmpNo,
                    EmpFirstName = request.EmpFirstName,
                    EmpLastName = request.EmpLastName,
                    City = request.City,
                    State = request.State,
                    Country = request.Country,
                    BeginDate = request.BeginDate,
                    EndDate = request.EndDate,
                    DateofJoined = request.DateofJoined
                };
                var isInserted = await InsertEmployee(entity, cancellationToken);
                await _mediator.Publish(new EmployeeCreated { EmpNo = entity.EmpNo }, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
