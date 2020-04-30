using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArtMuseum.Models;
using ArtMuseum.Services;
using Microsoft.AspNet.Identity;

namespace ArtMuseum.API.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        [Authorize]
        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employeeService = new EmployeeService(userId);
            return employeeService;
        }

        //POST
        [HttpPost]
        public IHttpActionResult Post(EmployeeCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateEmployeeService();
            if (!service.NewEmployee(model)) return InternalServerError();
            return Ok();
        }

        //GET--BY MUSEUM
        [HttpGet]
        [Route("museum")]
        public IHttpActionResult Get(int museum)
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employees = employeeService.GetEmployeesAtMuseum(museum);
            return Ok(employees);
        }

        //GET ALL
        
        public IHttpActionResult Get()
        {
            var service = CreateEmployeeService();
            var employees = service.GetAllEmployees();
            return Ok(employees);
        }

        //GET ONE--BY ID
        [HttpGet]
        [Route("emp-id")]
        public IHttpActionResult Get(string emp_id)
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employee = employeeService.GetEmployeeById(emp_id);
            return Ok(employee);
        }

        //PUT
        [HttpPut]
        public IHttpActionResult Put(EmployeeEdit model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateEmployeeService();
            if (!service.UpdateEmployee(model)) return InternalServerError();
            return Ok();
        }

        //DELETE
        
        public IHttpActionResult Delete(string emp_id)
        {
            var service = CreateEmployeeService();
            if (!service.DeleteEmployee(emp_id)) return InternalServerError();
            return Ok();
        }

    }
}
