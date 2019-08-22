using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CvsHealthCare.CqrsMediator.Application.Employees.Queries.GetEmployeeDetails
{
   public class GetEmployeeDetailQuery: IRequest<EmployeeDetailModel>
    {
        public int EmpNo { get; set; }
    }
}
