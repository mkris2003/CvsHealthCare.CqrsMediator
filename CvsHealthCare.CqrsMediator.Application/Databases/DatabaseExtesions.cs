using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CvsHealthCare.CqrsMediator.Application.Databases
{
    public static class DatabaseExtesions
    {
        public static SqlParameter WithValue(this SqlParameter parameter, object value)
        {
            parameter.Value = value;
            return parameter;
        }
    }
}
