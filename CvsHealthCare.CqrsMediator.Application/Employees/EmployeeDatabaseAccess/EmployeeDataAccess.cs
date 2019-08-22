using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CvsHealthCare.CqrsMediator.Application.Databases;
using CvsHealthCare.CqrsMediator.Domain.Entities;
using static CvsHealthCare.CqrsMediator.Application.Databases.DatabaseConnection;
namespace CvsHealthCare.CqrsMediator.Application.Employees.EmployeeDatabaseAccess
{
    public static class EmployeeDataAccess
    {
        private const string UspGetCountry = "usp_GetCountry", UspGetStates = "USP_GetStates",
            UspGetCities = "USP_GetCities", UspGetEmployeeDetails = "USP_GetEmployeeDetails",
            UspInsertCountry = "USP_InsertCountry", UspUpdateCountry = "USP_UpdateCountry",
            UspDeleteCountry = "USP_DeleteCountry", UspInsertStates = "USP_InsertStates",
            UspUpdateStates = "USP_UpdateStates", UspDeleteStates = "USP_DeleteStates",
            UspInsertCity = "USP_InsertCity", UspUpdateCity = "USP_UpdateCity", UspDeleteCity = "USP_DeleteCity",
            UspInsertEmployeeDetails = "USP_InsertEmployeeDetails", UspUpdateEmployeeDetails = "USP_UpdateEmployeeDetails",
            UspDeleteEmployeeDetails = "USP_DeleteEmployeeDetails";
        private const string CountryId = "@CountryId", CountryName = "@CountryName", StateId = "@StateId", EmpNo = "@EmpNo", EmpFirstName = "@EmpFirstName",
            EmpLastName = "@EmpLastName", City = "@City", State = "@State", Country = "@Country", BeginDate = "@BeginDate",
            EndDate = "@EndDate", PageNo = "@PageNo", PageSize = "@PageSize", SortColumn = "@SortColumn", SortOrder = "@SortOrder",
            StateName = "@StateName", CityName = "@CityName", CityId = "@CityId", DateofJoined = "@DateofJoined";

        public static DataSet CountryDetails()
        {
            try
            {
                return SqlHelper.ExecuteDataset(DatabaseConnectionstring, CommandType.StoredProcedure, UspGetCountry);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public static void InsertCountry(Country country)
        {
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(CountryId, SqlDbType.Int).WithValue(country.CountryId),
                    new SqlParameter(CountryName, SqlDbType.VarChar,50).WithValue(country.CountryName),
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspInsertCountry, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static void UpdateCountry(Country country)
        {
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(CountryId, SqlDbType.Int).WithValue(country.CountryId),
                    new SqlParameter(CountryName, SqlDbType.VarChar,50).WithValue(country.CountryName),
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspUpdateCountry, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static void DeleteCountry(int countryId)
        {
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(CountryId, SqlDbType.Int).WithValue(countryId)
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspDeleteCountry, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static DataSet StateDetails(int countryId)
        {
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(CountryId, SqlDbType.Int).WithValue(countryId)
                };
                return SqlHelper.ExecuteDataset(DatabaseConnectionstring, CommandType.StoredProcedure, UspGetStates, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public static void InsertState(State state)
        {
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(StateId, SqlDbType.Int).WithValue(state.StateId),
                    new SqlParameter(StateName, SqlDbType.VarChar,50).WithValue(state.StateName),
                    new SqlParameter(CountryId, SqlDbType.Int).WithValue(state.CountryId),
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspInsertStates, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static void UpdateState(State state)
        {
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(StateId, SqlDbType.Int).WithValue(state.StateId),
                    new SqlParameter(StateName, SqlDbType.VarChar,50).WithValue(state.StateName),
                    new SqlParameter(CountryId, SqlDbType.Int).WithValue(state.CountryId),
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspUpdateStates, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static void DeleteState(int stateId)
        {
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(StateId, SqlDbType.Int).WithValue(stateId),
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspDeleteStates, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static DataSet CityDetails(int countryId, int stateId)
        {
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(CountryId, SqlDbType.Int).WithValue(countryId),
                    new SqlParameter(StateId, SqlDbType.Int).WithValue(stateId)
                };
                return SqlHelper.ExecuteDataset(DatabaseConnectionstring, CommandType.StoredProcedure, UspGetCities, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public static void InsertCity(City city)
        {
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(CityId, SqlDbType.Int).WithValue(city.CityId),
                    new SqlParameter(CityName, SqlDbType.VarChar,50).WithValue(city.CityName),
                    new SqlParameter(StateId, SqlDbType.Int).WithValue(city.StateId),
                    new SqlParameter(CountryId, SqlDbType.Int).WithValue(city.CountryId),
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspInsertCity, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static void UpdateCity(City city)
        {
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(CityId, SqlDbType.Int).WithValue(city.CityId),
                    new SqlParameter(CityName, SqlDbType.VarChar,50).WithValue(city.CityName),
                    new SqlParameter(StateId, SqlDbType.Int).WithValue(city.StateId),
                    new SqlParameter(CountryId, SqlDbType.Int).WithValue(city.CountryId),
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspUpdateCity, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static void DeleteCity(int cityId)
        {
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(CityId, SqlDbType.Int).WithValue(cityId)
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspDeleteCity, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static Task< DataSet> EmployeeDetails(Employee employee, CancellationToken token)
        {
            var tokenSource = new CancellationTokenSource();
            if (token.IsCancellationRequested)
            {
                tokenSource.Cancel();
                return Task.FromResult(new DataSet());
            }
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(EmpNo, SqlDbType.Int).WithValue(employee.EmpNo),
                    new SqlParameter(EmpFirstName, SqlDbType.VarChar,50).WithValue(employee.EmpFirstName),
                    new SqlParameter(EmpLastName, SqlDbType.VarChar,50).WithValue(employee.EmpLastName),
                    new SqlParameter(City, SqlDbType.VarChar,50).WithValue(employee.City),
                    new SqlParameter(State, SqlDbType.VarChar,50).WithValue(employee.State),
                    new SqlParameter(Country, SqlDbType.VarChar,50).WithValue(employee.Country),
                    new SqlParameter(BeginDate, SqlDbType.DateTime2).WithValue(employee.BeginDate),
                    new SqlParameter(EndDate, SqlDbType.DateTime2).WithValue(employee.EndDate),
                    new SqlParameter(PageNo, SqlDbType.Int).WithValue(employee.PageNo),
                    new SqlParameter(PageSize, SqlDbType.Int).WithValue(employee.PageSize),
                    new SqlParameter(SortColumn, SqlDbType.VarChar,50).WithValue(employee.SortColumn),
                    new SqlParameter(SortOrder, SqlDbType.VarChar,50).WithValue(employee.SortOrder)
                };
                var dsEmployees= SqlHelper.ExecuteDataset(DatabaseConnectionstring, CommandType.StoredProcedure, UspGetEmployeeDetails, employeeParams.ToArray());
                return Task.FromResult(dsEmployees);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public static Task<bool> InsertEmployee(Employee employee, CancellationToken token)
        {
            var tokenSource = new CancellationTokenSource();
            if (token.IsCancellationRequested)
            {
                tokenSource.Cancel();
                return Task.FromResult(false);
            }
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(EmpNo, SqlDbType.Int).WithValue(employee.EmpNo),
                    new SqlParameter(EmpFirstName, SqlDbType.VarChar,50).WithValue(employee.EmpFirstName),
                    new SqlParameter(EmpLastName, SqlDbType.VarChar,50).WithValue(employee.EmpLastName),
                    new SqlParameter(City, SqlDbType.VarChar,50).WithValue(employee.City),
                    new SqlParameter(State, SqlDbType.VarChar,50).WithValue(employee.State),
                    new SqlParameter(Country, SqlDbType.VarChar,50).WithValue(employee.Country),
                    new SqlParameter(DateofJoined, SqlDbType.VarChar,50).WithValue(employee.DateofJoined),
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspInsertEmployeeDetails, employeeParams.ToArray());
                return Task.FromResult(true);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public static Task<bool> UpdateEmployees(Employee employee, CancellationToken token)
        {
            var tokenSource = new CancellationTokenSource();
            if (token.IsCancellationRequested)
            {
                tokenSource.Cancel();
                return Task.FromResult(false);
            }
            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(EmpNo, SqlDbType.Int).WithValue(employee.EmpNo),
                    new SqlParameter(EmpFirstName, SqlDbType.VarChar,50).WithValue(employee.EmpFirstName),
                    new SqlParameter(EmpLastName, SqlDbType.VarChar,50).WithValue(employee.EmpLastName),
                    new SqlParameter(City, SqlDbType.VarChar,50).WithValue(employee.City),
                    new SqlParameter(State, SqlDbType.VarChar,50).WithValue(employee.State),
                    new SqlParameter(Country, SqlDbType.VarChar,50).WithValue(employee.Country),
                    new SqlParameter(DateofJoined, SqlDbType.VarChar,50).WithValue(employee.DateofJoined),
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspUpdateEmployeeDetails, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return Task.FromResult(true);
        }
        public static  Task<bool>  DeleteEmployees(int employeeId, CancellationToken token)
        {
            var tokenSource = new CancellationTokenSource();
            if (token.IsCancellationRequested)
            {
                tokenSource.Cancel();
                return Task.FromResult(false);
            }

            try
            {
                var employeeParams = new List<SqlParameter>
                {
                    new SqlParameter(EmpNo, SqlDbType.Int).WithValue(employeeId)
                };
                SqlHelper.ExecuteNonQuery(DatabaseConnectionstring, CommandType.StoredProcedure, UspDeleteEmployeeDetails, employeeParams.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return Task.FromResult(true);
        }
    }
}
