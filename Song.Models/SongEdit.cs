using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Song.Models
{
    public class SongEdit
    {
        public int SongId { get; set; }
        public string SongName { get; set; }

        
        public string ArtistId { get; set; }
    }
}
