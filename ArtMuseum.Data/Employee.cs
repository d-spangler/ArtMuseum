using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Data
{
    public class Employee
    {
        [Key] public Guid EmployeeDbId { get; set; }

        [Required] public int Id { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string Position { get; set; }

        [Required] public string Location { get; set; }

        //public int ClearanceLevel {get; set;} -----Stretch Goal-----
    }
}
