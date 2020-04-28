using ArtMuseum.Data;
using ArtMuseum.Models;
using ArtMuseum.Services;
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
        //POST
        public IHttpActionResult Post(ArtworkCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = new ArtworkService();
            if (!service.CreateArtwork(model)) return InternalServerError();
            return Ok();
        }

        //GET ARTWORK BY ID
        [Route("id")]
        public IHttpActionResult Get(int id)
        {
            var service = new ArtworkService();
            var artwork = service.GetArtworkById(id);
            return Ok(artwork);
        }

        //GET BY NAME 
        [Route("name")]
        public IHttpActionResult GetByName(string name)
        {
            var service = new ArtworkService();
            var artwork = service.GetArtworkByName(name);
            return Ok(artwork);
        }

        //GET BY ARTIST
        [Route("artist")]
        public IHttpActionResult GetByArtist(string artists)
        {
            var service = new ArtworkService();
            var artwork = service.GetArtworkByArtist(artists);
            return Ok(artwork);
        }

        //GET BY MEDUIM
        [Route("medium")]
        public IHttpActionResult GetByMedium(string mediums)
        {
            var service = new ArtworkService();
            var artwork = service.GetArtworkByMedium(mediums);
            return Ok(artwork);
        }

        //GET BY TYPE
        [Route("types")]
        public IHttpActionResult GetByTypes(Enum types)
        {
            var service = new ArtworkService();
            var artwork = service.GetArtworkByTypes(types);
            return Ok(artwork);
        }

        //GET BY ERA
        [Route("era")]
        public IHttpActionResult GetByEra(Enum era)
        {
            var service = new ArtworkService();
            var artwork = service.GetArtworkByEra(era);
            return Ok(artwork);
        }

        //PUT
        public IHttpActionResult Put(ArtworkEdit model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = new ArtworkService();
            if (!service.UpdateArtwork(model)) return InternalServerError();
            return Ok();
        }

        //DELETE
        public IHttpActionResult Delete(int id)
        {
            var service = new ArtworkService();
            if (!service.DeleteArtwork(id)) return InternalServerError();
            return Ok();
        }
    }
}
