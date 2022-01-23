using Microsoft.AspNet.Identity;
using Song.Models;
using SongProject.Models;
using SongProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SongProject.Controllers
{
    [Authorize]
    public class SongController : ApiController
    {
        private SongService CreateSongService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var songService = new SongService(userId);
            return songService;
        }

        public IHttpActionResult Get()
        {
            SongService songService = CreateSongService();
            var song = songService.GetSongs();
            return Ok(song);
        }

        public IHttpActionResult Post(AddSong song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.CreateSong(song))
                return InternalServerError();

            return Ok();
        }
    }
}
