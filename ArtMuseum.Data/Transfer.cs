using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Data
{
    public class Transfer
    {
        [Key]
        public Guid TransferId { get; set; }

        [Required]
        public string MuseumSend { get; set; }

        [Required]
        public string MuseumGet { get; set; }

        [Required]
        public DateTime DateOfTransfer { get; set; }

        [Required]
        public int LengthOfTransfer { get; set; }
    }
}
