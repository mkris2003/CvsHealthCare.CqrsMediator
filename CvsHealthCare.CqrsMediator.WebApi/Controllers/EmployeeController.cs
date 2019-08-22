using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CvsHealthCare.CqrsMediator.Application.Employees.Commands.CreateEmployee;
using CvsHealthCare.CqrsMediator.Application.Employees.Commands.DeleteEmployee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace CvsHealthCare.CqrsMediator.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        /// <summary>
        /// https://localhost:44368/api/Employee/5000
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var createEmployeeCommand = new CreateEmployeeCommand()
            {
                EmpNo = 1000,
                EmpFirstName = "Murali",
                EmpLastName = "Konanki",
                City = "Kdkr",
                State = "AP",
                Country = "India",
                DateofJoined = DateTime.Now
            };
           var jsonString= JsonConvert.SerializeObject(createEmployeeCommand);

            await Mediator.Send(new DeleteEmployeeCommand {EmpNo= id });

            return NoContent();
        }
        /// <summary>
        /// Content-Type: application/json;odata=verbose;charset=utf-8
        /// {"EmpNo":1000,"EmpFirstName":"Murali","EmpLastName":"Konanki","City":"Kdkr","State":"AP","Country":"India","BeginDate":"0001-01-01T00:00:00","EndDate":"0001-01-01T00:00:00","DateofJoined":"2019-08-04T22:12:38.28024-07:00"}
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateEmployeeCommand command)
        {
            
            await Mediator.Send(command);

            return NoContent();
        }
    }
}