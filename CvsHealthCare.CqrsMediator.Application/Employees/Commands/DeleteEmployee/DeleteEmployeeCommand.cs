using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CvsHealthCare.CqrsMediator.Application.Employees.Commands.DeleteEmployee
{
   public  class DeleteEmployeeCommand:IRequest
    {
        public int EmpNo { get; set; }
    }
}
