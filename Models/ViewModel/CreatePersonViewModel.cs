using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.ViewModel
{
    public class CreatePersonViewModel
    {
        [Required]
        
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }

        

        
        

    }
}
