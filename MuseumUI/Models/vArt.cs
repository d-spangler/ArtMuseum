using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumUI.Models
{
    public enum Types { FrescoPainting = 1, Painting, Sculpture }

    public enum Era { Renaissance = 1, Realism, Hellenistic, Impressionism, Romantic, Baroque }

    public class vArt
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

        [ForeignKey(nameof(MuseumId))]
        public virtual Museum Museum { get; set; }
    }
}
