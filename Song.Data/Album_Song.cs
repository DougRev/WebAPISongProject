using SongProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Song.Data
{
    public class Album_Song
    {
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }

        [ForeignKey(nameof(Artist))]
        public int ArtistId{ get; set; }
        public virtual Songy Song { get; set; }
        public virtual Artist Artist { get; set; }

        
    }
}
