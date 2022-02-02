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
        [ForeignKey("Songy")]
        int SongId { get; set; }

        [ForeignKey("Artist")]
        int ArtistId{ get; set; }
        public virtual Songy Song { get; set; }
        public virtual Artist Artist { get; set; }

        
    }
}
