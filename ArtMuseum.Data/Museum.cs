﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Data
{
    public class Museum
    {
        [Key]
        public int MuseumId { get; set; }

        [Required]
        public string MuseumName { get; set; }

        [Required]
        public string LocationCity { get; set; }

        [Required]
        public string LocationCountry { get; set; }

        [Required]
        public int CountryCode { get; set; }



        //[ForeignKey(nameof(Artwork))]
        //public virtual Artwork Artwork { get; set; }

        //[ForeignKey(nameof(MuseumId))]
        //public virtual Employee Employee { get; set; }

        //public ICollection<Artwork> CollectedWorks { get; set; }
    }
}
