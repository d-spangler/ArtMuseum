using ArtMuseum.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Models
{
    public class ArtworkDetail
    {
        public int ArtworkId { get; set; }

        [Display(Name = "Name of Art Piece")]
        public string NameOfPiece { get; set; }

        [Display(Name = "Name of Artist")]
        public string Artist { get; set; }

        [Display(Name = "Location of Piece")]
        public string MuseumName { get; set; }

        [Display(Name = "Medium")]
        public string Medium { get; set; }

        [Display(Name = "Type")]
        public Types Types { get; set; }

        [Display(Name = "Era")]
        public Era Era { get; set; }
    }
}
