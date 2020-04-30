using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Models
{
    public class MuseumDetail
    {
        public int MuseumId { get; set; }
        
        [Display(Name ="Name")]
        public string MuseumName { get; set; }

        [Display(Name ="City")]
        public string LocationCity { get; set; }

        [Display(Name = "Country")]
        public string LocationCountry { get; set; }

        [Display(Name ="Country Code")]
        public string CountryCode { get; set; }


    }
}
