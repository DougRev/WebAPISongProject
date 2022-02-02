using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongProject.Data
{
    public class Album
    {
            [Key]
            public int AlbumId { get; set; }
            public Guid OwnerId { get; set; }
            [Required]
            public string AlbumName { get; set; }
            [Required]
            [ForeignKey("Artist")]
            public int ArtistId { get; set; }
            public DateTimeOffset CreatedUtc { get; set; }
            public DateTimeOffset ModifiedUtc { get; set; }
            public virtual Artist Artist { get; set; }
        }
}
