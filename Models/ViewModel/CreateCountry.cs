using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.ViewModel
{
    public class CreateCountry
    {
        
        [StringLength(30, MinimumLength = 3)]
        public string CountryName { get; set; }
        
        
       
    }
}
