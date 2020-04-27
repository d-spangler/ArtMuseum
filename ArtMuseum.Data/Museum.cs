using System;
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

        public int CountryCode { get; set; }

        public ICollection<Artwork> CollectedWorks { get; set; }
    }
}
