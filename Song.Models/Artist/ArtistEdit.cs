using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Song.Models.Album
{
    public class ArtistEdit
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

    }
}
