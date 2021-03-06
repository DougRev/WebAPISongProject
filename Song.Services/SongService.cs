using Song.Data;
using Song.Models;
using SongProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongProject.Services
{
    public class SongService
    {
        private readonly Guid _userId;
        public SongService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSong(AddSong model)
        {
            var entity =
                new Songy()
                {
                    OwnerId = _userId,
                    SongName = model.SongName,
                    Genre = model.Genre,
                    CreatedUtc = DateTime.Now,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public SongDetail GetSongById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Songs
                    .Single(e => e.SongId == id && e.OwnerId == _userId);
                    return
                    new SongDetail
                    {
                        SongId = entity.SongId,
                        SongName = entity.SongName,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public IEnumerable<SongList> GetSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                        new SongList
                        {
                            SongId = e.SongId,
                            ArtistId = e.ArtistId,
                            SongName = e.SongName,
                            CreatedUtc = e.CreatedUtc
                        }
            );


                return query.ToArray();
            }

        }
            public bool UpdateSong(SongEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Songs
                    .Single(e => e.SongId == model.SongId);
                entity.SongName = model.SongName;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

        }
            public bool DeleteSong(int songId)
            {
                using (var ctx =new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Songs
                    .Single(e => e.SongId == songId && e.OwnerId == _userId);

                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
            }
    }
}
