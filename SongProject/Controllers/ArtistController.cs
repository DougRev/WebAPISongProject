using Microsoft.AspNet.Identity;
using Song.Models.Album;
using Song.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SongProjectWebAPI.Controllers
{
    [Authorize]
    public class ArtistController : ApiController
    {
            private ArtistServices CreateArtistServices()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var artistService = new ArtistServices(userId);
                return artistService;
            }

            [HttpGet]
            public IHttpActionResult Get()
            {
                ArtistServices artistService = CreateArtistServices();
                var song = artistService.GetArtists();
                return Ok(song);
            }

            [HttpGet]
            public IHttpActionResult Get(int id)
            {
                ArtistServices artistService = CreateArtistServices();
                var artist = artistService.GetArtistById(id);
                return Ok(artist);
            }
            [HttpPost]
            public IHttpActionResult CreateArtist(ArtistCreate artist)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateArtistServices();

                if (!service.CreateArtist(artist))
                    return InternalServerError();

                return Ok("Artist has been added");
            }

            [HttpPut]
            public IHttpActionResult UpdateSong(ArtistEdit artist)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateArtistServices();

                if (!service.UpdateArtist(artist))
                    return InternalServerError();

                return Ok();
            }

            [HttpDelete]
            public IHttpActionResult DeleteSong(int id)
            {
                var service = CreateArtistServices();

                if (!service.DeleteArtist(id))
                    return InternalServerError();

                return Ok("Artist Deleted");
            }
        }
}
