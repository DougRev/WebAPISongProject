using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Song.Models
{
    public class AddSong
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Title must be shorter")]
        public string Title { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Artist name must be shorter")]
        public string Artist { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Genre name must be shorter")]
        public string Genre { get; set; }
        
    }
}
