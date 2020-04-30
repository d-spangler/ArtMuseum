using ArtMuseum.Data;
using ArtMuseum.Models;
using ArtMuseum.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArtMuseum.API.Controllers
{
    [RoutePrefix("API/values")]
    public class ArtworkController : ApiController
    {
        private ArtworkService CreateArtworkService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var artworkService = new ArtworkService(userId);
            return artworkService;
        }

        //POST
        [HttpPost]
        public IHttpActionResult Post(ArtworkCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateArtworkService();
            if (!service.CreateArtwork(model)) return InternalServerError();
            return Ok();
        }

        //GET ALL
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ArtworkService artworkService = CreateArtworkService();
            var artwork = artworkService.GetArtwork();
            return Ok(artwork);
        }

        //GET ARTWORK BY ID
        [HttpGet]
        [Route("id")]
        public IHttpActionResult Get(int id)
        {
            ArtworkService artworkService = CreateArtworkService();
            var artwork = artworkService.GetArtworkById(id);
            return Ok(artwork);
        }

        //GET BY NAME 
        [HttpGet]
        [Route("name")]
        public IHttpActionResult GetByName(string name)
        {
            ArtworkService artworkService = CreateArtworkService();
            var artwork = artworkService.GetArtworkByName(name);
            return Ok(artwork);
        }

        //GET BY ARTIST
        [HttpGet]
        [Route("artist")]
        public IHttpActionResult GetByArtist(string artists)
        {
            ArtworkService artworkService = CreateArtworkService();
            var artwork = artworkService.GetArtworkByArtist(artists);
            return Ok(artwork);
        }

        //GET BY MEDUIM
        [HttpGet]
        [Route("medium")]
        public IHttpActionResult GetByMedium(string mediums)
        {
            ArtworkService artworkService = CreateArtworkService();
            var artwork = artworkService.GetArtworkByMedium(mediums);
            return Ok(artwork);
        }

        //GET BY TYPE
        [HttpGet]
        [Route("types")]
        public IHttpActionResult GetByTypes(string types)
        {
            ArtworkService artworkService = CreateArtworkService();
            var artwork = artworkService.GetArtworkByTypes(types);
            return Ok(artwork);
        }

        //GET BY ERA
        [HttpGet]
        [Route("era")]
        public IHttpActionResult GetByEra(string era)
        {
            ArtworkService artworkService = CreateArtworkService();
            var artwork = artworkService.GetArtworkByEra(era);
            return Ok(artwork);
        }

        //PUT
        [HttpPut]
        public IHttpActionResult Put(ArtworkEdit model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateArtworkService();
            if (!service.UpdateArtwork(model)) return InternalServerError();
            return Ok();
        }

        //DELETE
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateArtworkService();
            if (!service.DeleteArtwork(id)) return InternalServerError();
            return Ok();
        }
    }
}
