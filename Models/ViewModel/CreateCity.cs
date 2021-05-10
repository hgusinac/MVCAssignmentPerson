using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.ViewModel
{
    public class CreateCity
    {
        
        [StringLength(50, MinimumLength = 3)]
        public string CityName { get; set; }
        
        public int CountryId { get; set; }

        public List<Country> CountryList { get; set; }
    }
}
