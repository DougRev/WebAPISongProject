using SongProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Song.Models
{
    public class SongList
    {
        public int SongId { get; set; }

        public int ArtistId { get; set; }
        public string SongName { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
