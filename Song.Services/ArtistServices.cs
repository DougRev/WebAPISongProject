using Song.Data;
using Song.Models.Album;
using SongProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Song.Services
{
    public class ArtistServices
    {
        private readonly Guid _userId;
        public ArtistServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateArtist(ArtistCreate model)
        {
            var entity =
                new Artist()
                {
                    OwnerId = _userId,
                    ArtistName = model.ArtistName,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ArtistDetails GetArtistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.ArtistId == id && e.OwnerId == _userId);
                return
                new ArtistDetails
                {
                    ArtistId = entity.ArtistId,
                    ArtistName = entity.ArtistName,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }
        public IEnumerable<ArtistListItem> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artists
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                        new ArtistListItem
                        {
                            ArtistId = e.ArtistId,
                            ArtistName = e.ArtistName,
                            CreatedUtc = e.CreatedUtc
                        }
            );


                return query.ToArray();
            }

        }
        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Artists
                    .Single(e => e.ArtistId == model.ArtistId);
                entity.ArtistName = model.ArtistName;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteArtist(int artistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.ArtistId == artistId && e.OwnerId == _userId);

                ctx.Artists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
