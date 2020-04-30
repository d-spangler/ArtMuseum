using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using AutoMapper.Internal;
using System.Web.Http.Controllers;
using ArtMuseum.Services;
using ArtMuseum.Models;

namespace ArtMuseum.API.Controllers
{
    [Authorize]
    public class MuseumController : ApiController
    {
        private MuseumServices CreateMuseumService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var museumService = new MuseumServices(userId);
            return museumService;
        }

        [HttpGet]//Get all museums
        public IHttpActionResult Get()
        {
            MuseumServices museumServices = CreateMuseumService();
            var museums = museumServices.GetMuseums();
            return Ok(museums);
        }

        [HttpGet]//Get by id
        [Route("id")]
        public IHttpActionResult Get(int id)
        {
            MuseumServices museumServices = CreateMuseumService();
            var museum = museumServices.GetMuseumById(id);
            return Ok(museum);
        }

        [HttpGet]//Get by name
        [Route("name")]
        public IHttpActionResult Get(string name)
        {
            MuseumServices museumServices = CreateMuseumService();
            var museum = museumServices.GetMuseumByName(name);
            return Ok(museum);
        }

        /*[HttpGet]//Get collection via museum id
        [Route("getcollection")]
        public IHttpActionResult Get([FromUri]int id)
        {
            MuseumServices museumServices = CreateMuseumService();
            var museum = museumServices.GetMuseumById(id);
            return ICollection<CollectedWorks>
        }*/


        [HttpPost]//Create
        public IHttpActionResult Post(MuseumCreate museum)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMuseumService();

            if (!service.CreateMuseum(museum))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]//Edit
        public IHttpActionResult Put(MuseumEdit museum)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMuseumService();

            if (!service.UpdateMuseum(museum))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]//Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMuseumService();

            if (!service.DeleteMuseum(id))
                return InternalServerError();

            return Ok();
        }
    }
}
