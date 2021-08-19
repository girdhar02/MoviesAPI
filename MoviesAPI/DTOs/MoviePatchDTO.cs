using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.DTOs
{
    public class MoviePatchDTO
    {
        [Required]
        [StringLength(300)]
        public string Tittle { get; set; }
        public string Summary { get; set; }
        public bool InTheater { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
