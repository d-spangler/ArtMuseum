using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Data
{
    public class Museums
    {
        [Key]
        public Guid MuseumId { get; set; }

        [Required]
        public string MuseumName { get; set; }

        [Required]
        public string LocationCity { get; set; }

        [Required]
        public string LocationCountry { get; set; }

        [Required]
        public int CountryCode { get; set; }

        public ICollection<string> CollectedWorks { get; set; }
    }
}
