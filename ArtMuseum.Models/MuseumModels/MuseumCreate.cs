using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Models
{
    public class MuseumCreate
    {
        [Required]
        public string MuseumName { get; set; }

        [Required]
        public string LocationCity { get; set; }

        [Required]
        public string LocationCountry { get; set; }

        [Required]
        public string CountryCode { get; set; }
    }
}
