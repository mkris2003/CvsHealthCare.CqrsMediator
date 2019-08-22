using System;
using System.Collections.Generic;
using System.Text;
using CvsHealthCare.CqrsMediator.Common;

namespace CvsHealthCare.CqrsMediator.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
