using ArtMuseum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Models
{
    public class ArtworkEdit
    {
        public int ArtworkId { get; set; }

        public string NameOfPiece { get; set; }

        public string Artist { get; set; }

        public string Description { get; set; }

        public int MuseumId { get; set; }

        public bool Availability { get; set; }

        public string Medium { get; set; }

        public Types Types { get; set; }

        public Era Era { get; set; }
    }
}
