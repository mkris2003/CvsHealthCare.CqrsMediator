using System;
using System.Collections.Generic;
using System.Text;

namespace CvsHealthCare.CqrsMediator.Common
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
