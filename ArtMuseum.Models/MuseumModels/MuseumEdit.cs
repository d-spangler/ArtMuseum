using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Models
{
    public class MuseumEdit
    {
        public int MuseumId { get; set; }
        public string MuseumName { get; set; }

        public string LocationCity { get; set; }

        public string LocationCountry { get; set; }
        public string CountryCode { get; set; }
    }
}
