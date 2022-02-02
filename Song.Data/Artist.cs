using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Song.Data
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string ArtistName { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
