using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArtMuseum.Models;
using ArtMuseum.Services;

namespace ArtMuseum.API.Controllers
{
    public class EmployeeController : ApiController
    {
        //POST
        public IHttpActionResult Post(EmployeeCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = new EmployeeService();
            if (!service.NewEmployee(model)) return InternalServerError();
            return Ok();
        }



        //GET ALL--BY MUSEUM
        [Route("museum")]
        public IHttpActionResult Get(int museum)
        {
            var service = new EmployeeService();
            var employees = service.GetEmployeesAtMuseum(museum);
            return Ok(employees);
        }

        //GET ONE--BY ID
        [Route("id")]
        public IHttpActionResult Get(string id)
        {
            var service = new EmployeeService();
            var employee = service.GetEmployeeById(id);
            return Ok(employee);
        }




    }
}
