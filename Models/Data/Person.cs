using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAssignmentPerson.Models.Data
{
    public class Person
    {
       [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength (60)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        [ForeignKey("InCity")]
        public int InCityId { get; set; }

        public City InCity { get; set; }





    }
}
