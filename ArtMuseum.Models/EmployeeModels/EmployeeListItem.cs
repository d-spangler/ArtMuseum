using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Models
{
    public class EmployeeListItem
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        //public int ClearanceLevel {get; set;} -----Stretch Goal-----
    }
}
