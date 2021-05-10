using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Data
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        
        public string CountryName { get; set; }
        
        public List<City> CityInCountry { get; set; }
       
        

    }
}
