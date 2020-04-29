﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Data
{
    public enum Types { FrescoPainting = 1, Painting, Sculpture }
   
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
        public int MuseumId { get; set; }

        [ForeignKey(nameof(MuseumId))]
        public virtual Museum Museum { get; set; }

        [Required]
        public bool Availability { get; set; }

        [Required]
        public string Medium { get; set; }

        [Required]
        public Types Types { get; set;  }

        [Required]
        public Era Era { get; set; }

    }
}
