﻿using Song.Data;
using Song.Models;
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
        public SongService (Guid userId)
        {
            _userId = userId;
        }
        
        public bool CreateSong(AddSong model)
        {
            var entity =
                new Songy()
            {
                OwnerId = _userId,
                Title = model.Title,
                Artist = model.Artitst,
                Genre = model.Genre
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
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
                            Title = e.Title,
                            CreatedUtc = e.CreatedUtc 
                        }
                  );
            return query.ToArray();
            }
        }
    }
}