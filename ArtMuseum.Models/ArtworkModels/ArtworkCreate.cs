using ArtMuseum.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Models
{
    public class ArtworkCreate
    {
        //nameofpiece type 
        [Required]
        public string NameOfPiece { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string LocationOfArtwork { get; set; }

        public bool Availability { get; set; }

        [Required]
        public string Medium { get; set; }

        [Required]
        public Types Types { get; set; }

        [Required]
        public Era Era { get; set; }
    }
}
