using System;
using System.Collections.Generic;
using System.Text;
using CvsHealthCare.CqrsMediator.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using static CvsHealthCare.CqrsMediator.Application.Databases.DatabaseConnection;
namespace CvsHealthCare.CqrsMediator.Application.Databases
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfigurationRoot _configuration;
        private readonly static string _connectionStringName = "EmployeeConnection";

        public SqlConnectionFactory(IConfigurationRoot configuration)
        {
            _configuration = configuration;
            DatabaseConnectionstring = _configuration.GetConnectionString(_connectionStringName);

        }
        public string ConnectionString()
        {
            return DatabaseConnectionstring;
        }
    }
}
