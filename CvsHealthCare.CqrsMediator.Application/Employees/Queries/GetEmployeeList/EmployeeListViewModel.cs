using System;
using System.Collections.Generic;
using System.Text;

namespace CvsHealthCare.CqrsMediator.Application.Employees.Queries.GetEmployeeList
{
   public class EmployeeListViewModel
    {
        public IList<EmployeeLookupModel> EmployeeList { get; set; }
    }
}
