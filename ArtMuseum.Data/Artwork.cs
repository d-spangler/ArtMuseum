using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Data
{
    public enum Type { FrescoPainting = 1, Painting, Sculpture }
    public enum Era { Renaissance = 1, Realism, Hellenistic, Impressionism, Romantic, Baroque }

    public class Artwork
    {
        [Key]
        public int ArtworkId { get; set; }

        [Required]
        public string NameOfPiece { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string LocationOfArtwork { get; set; }

        [Required]
        public bool Availability { get; set; }

        [Required]
        public string Medium { get; set; }

        [Required]
        public Type Type { get; set; }

        [Required]
        public Era Era { get; set; }

    }
}
