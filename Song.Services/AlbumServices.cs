using Song.Data;
using Song.Models.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongProject.Services
{
    public class AlbumServices
    {
        private readonly Guid _userId;
        public AlbumServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateArtist(AlbumCreate model)
        {
            var entity =
                new Album()
                {
                    OwnerId = _userId,
                    AlbumName = model.AlbumName,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public AlbumDetails GetAlbumById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Albums
                    .Single(e => e.AlbumId == id && e.OwnerId == _userId);
                return
                new AlbumDetails
                {
                    AlbumId = entity.AlbumId,
                    AlbumName = entity.AlbumName,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }
        public IEnumerable<AlbumListItem> GetAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Albums
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                        new AlbumListItem
                        {
                            AlbumId = e.AlbumId,
                            AlbumName = e.AlbumName,
                            CreatedUtc = e.CreatedUtc
                        }
            );


                return query.ToArray();
            }

        }
        public bool UpdateAlbum(AlbumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Albums
                    .Single(e => e.AlbumId == model.AlbumId);
                entity.AlbumName = model.AlbumName;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteAlbum(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Albums
                    .Single(e => e.AlbumId == albumId && e.OwnerId == _userId);

                ctx.Albums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
