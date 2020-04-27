using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Data
{
    public class Employee
    {
        [Key] public int EmployeeDbId { get; set; }

        [Required] public string Id { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string Position { get; set; }

        [Required] public string Museum { get; set; }

        [ForeignKey(nameof(Location))]
        public int Location { get; set; }

        //public int ClearanceLevel {get; set;} -----Stretch Goal-----
    }
}
