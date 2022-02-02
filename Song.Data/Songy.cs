using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongProject.Data
{
    public class Songy
    {
        [Key]
        public int SongId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string SongName { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public string Genre { get; set; }
        public string RunTime { get; set; }
        public string Lyrics { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public virtual Artist Artist { get; set; }

    }
}
